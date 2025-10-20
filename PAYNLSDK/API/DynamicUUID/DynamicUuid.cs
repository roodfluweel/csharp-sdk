using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.DynamicUUID
{
    /// <summary>
    /// Provides helpers to create, validate and decode Dynamic UUIDs for Pay.nl.
    /// </summary>
    public static class DynamicUuid
    {
        private const char Prefix = 'b';
        private const string ServiceIdDigitsPattern = "[^0-9]";
        private const string UuidAllowedCharactersPattern = "[^0-9a-z]";
        private static readonly Encoding AsciiEncoding = Encoding.ASCII;

        /// <summary>
        /// Generates a Dynamic UUID based on the supplied service id, secret and reference.
        /// </summary>
        /// <param name="serviceId">The service id (SL-0000-0000).</param>
        /// <param name="secret">The 40 character secret in hexadecimal form.</param>
        /// <param name="reference">The merchant reference.</param>
        /// <param name="padChar">The pad character for the reference when less than 16 hex characters.</param>
        /// <param name="referenceType">Indicates whether the reference is plain text or hexadecimal.</param>
        /// <returns>The generated UUID.</returns>
        public static string Encode(
            string serviceId,
            string secret,
            string reference,
            char padChar = '0',
            DynamicUuidReferenceType referenceType = DynamicUuidReferenceType.String)
        {
            ValidateServiceId(serviceId);
            ValidateSecret(secret);
            ValidatePadChar(padChar);

            var referenceHex = ConvertReferenceToHex(reference, referenceType);
            var sanitizedServiceId = Regex.Replace(serviceId, ServiceIdDigitsPattern, string.Empty);
            var paddedReference = referenceHex.ToLowerInvariant().PadLeft(16, char.ToLowerInvariant(padChar));
            var uuidData = sanitizedServiceId + paddedReference;
            var signature = ComputeSignature(uuidData, secret);

            var uuid = string.Concat(Prefix, signature.Substring(0, 7), uuidData);
            return FormatUuid(uuid);
        }

        /// <summary>
        /// Validates a Dynamic UUID against the provided secret.
        /// </summary>
        /// <param name="uuid">The UUID to validate.</param>
        /// <param name="secret">The 40 character secret in hexadecimal form.</param>
        /// <returns><c>true</c> if the UUID signature matches the secret; otherwise <c>false</c>.</returns>
        public static bool Validate(string uuid, string secret)
        {
            ValidateSecret(secret);

            var normalizedUuid = NormalizeUuid(uuid);
            if (normalizedUuid.Length != 32)
            {
                return false;
            }

            var uuidData = normalizedUuid.Substring(8);
            var expectedPrefix = Prefix + ComputeSignature(uuidData, secret).Substring(0, 7);
            return string.Equals(expectedPrefix, normalizedUuid.Substring(0, 8), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Decodes a UUID to retrieve the service id and reference.
        /// </summary>
        /// <param name="uuid">The UUID to decode.</param>
        /// <param name="secret">Optional secret to validate the UUID before decoding.</param>
        /// <param name="padChar">The pad character that was used during encoding.</param>
        /// <param name="referenceType">Indicates whether the reference should be returned as string or hexadecimal.</param>
        /// <returns>The decoded information.</returns>
        public static DynamicUuidDecodeResult Decode(
            string uuid,
            string secret = null,
            char padChar = '0',
            DynamicUuidReferenceType referenceType = DynamicUuidReferenceType.String)
        {
            if (!string.IsNullOrWhiteSpace(secret) && !Validate(uuid, secret))
            {
                throw new PayNlException("Incorrect signature");
            }

            var normalizedUuid = NormalizeUuid(uuid);
            if (normalizedUuid.Length != 32)
            {
                throw new PayNlException("Invalid UUID");
            }

            var uuidData = normalizedUuid.Substring(8);
            var serviceIdDigits = uuidData.Substring(0, 8);
            var referenceHex = uuidData.Substring(8);

            var serviceId = $"SL-{serviceIdDigits.Substring(0, 4)}-{serviceIdDigits.Substring(4, 4)}";
            var trimmedReference = TrimReference(referenceHex, padChar);
            var reference = referenceType == DynamicUuidReferenceType.String
                ? ConvertHexToString(trimmedReference)
                : trimmedReference.ToLowerInvariant();

            return new DynamicUuidDecodeResult(serviceId, reference);
        }

        /// <summary>
        /// Builds QR-code information for Bancontact payments.
        /// </summary>
        /// <param name="uuid">The UUID to embed in the QR-code.</param>
        /// <param name="includeBase64">Indicates whether the base64 encoded QR image should be fetched.</param>
        /// <param name="imageDownloader">Optional delegate to download image bytes when <paramref name="includeBase64"/> is true.</param>
        /// <returns>The QR-code information.</returns>
        public static DynamicUuidQrCodeInfo GetBancontactQr(
            string uuid,
            bool includeBase64 = false,
            Func<Uri, byte[]> imageDownloader = null)
        {
            const string redirectBase = "https://qr.pisp.me/bc/";
            const string qrTemplate = "https://chart.googleapis.com/chart?cht=qr&chs=260x260&chl=";
            var qrUri = new Uri(qrTemplate + Uri.EscapeDataString(redirectBase + uuid));

            return CreateQrInfo(redirectBase + uuid, qrUri, includeBase64, imageDownloader);
        }

        /// <summary>
        /// Builds QR-code information for iDEAL payments.
        /// </summary>
        /// <param name="uuid">The UUID to embed in the QR-code.</param>
        /// <param name="includeBase64">Indicates whether the base64 encoded QR image should be fetched.</param>
        /// <param name="imageDownloader">Optional delegate to download image bytes when <paramref name="includeBase64"/> is true.</param>
        /// <returns>The QR-code information.</returns>
        public static DynamicUuidQrCodeInfo GetIdealQr(
            string uuid,
            bool includeBase64 = false,
            Func<Uri, byte[]> imageDownloader = null)
        {
            const string redirectBase = "https://qr6.ideal.nl/";
            const string qrTemplate = "https://ideal.pay.nl/qr/";
            var qrUri = new Uri(qrTemplate + uuid);

            return CreateQrInfo(redirectBase + uuid, qrUri, includeBase64, imageDownloader);
        }

        private static DynamicUuidQrCodeInfo CreateQrInfo(
            string url,
            Uri qrUri,
            bool includeBase64,
            Func<Uri, byte[]> imageDownloader)
        {
            var qrUrl = qrUri.ToString();
            var qrBase64 = includeBase64 ? DownloadBase64(qrUri, imageDownloader) : null;

            return new DynamicUuidQrCodeInfo(url, qrUrl, qrBase64);
        }

        private static string DownloadBase64(Uri uri, Func<Uri, byte[]> imageDownloader)
        {
            var downloader = imageDownloader ?? DefaultImageDownloader;
            var bytes = downloader(uri);
            return Convert.ToBase64String(bytes);
        }

        private static byte[] DefaultImageDownloader(Uri uri)
        {
            using var httpClient = new HttpClient();
            return httpClient.GetByteArrayAsync(uri).GetAwaiter().GetResult();
        }

        private static string ConvertReferenceToHex(string reference, DynamicUuidReferenceType referenceType)
        {
            if (referenceType == DynamicUuidReferenceType.Hex)
            {
                ValidateReferenceHex(reference);
                return reference.ToLowerInvariant();
            }

            ValidateReferenceString(reference);

            var builder = new StringBuilder(reference.Length * 2);
            foreach (var character in reference)
            {
                builder.Append(((int)character).ToString("x2"));
            }

            return builder.ToString();
        }

        private static string ConvertHexToString(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new PayNlException("Invalid reference length");
            }

            var bytes = HexStringToBytes(hex);
            return AsciiEncoding.GetString(bytes);
        }

        private static string TrimReference(string referenceHex, char padChar)
        {
            if (referenceHex.Length == 0)
            {
                return referenceHex;
            }

            var padString = new string(char.ToLowerInvariant(padChar), 1);
            return referenceHex.TrimStart(padString.ToCharArray());
        }

        private static string ComputeSignature(string uuidData, string secret)
        {
            var keyBytes = AsciiEncoding.GetBytes(secret.ToLowerInvariant());
            var dataBytes = AsciiEncoding.GetBytes(uuidData.ToLowerInvariant());

            using var hmac = new System.Security.Cryptography.HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(dataBytes);
            return BytesToHex(hashBytes);
        }

        private static string BytesToHex(IReadOnlyCollection<byte> bytes)
        {
            var builder = new StringBuilder(bytes.Count * 2);
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        private static byte[] HexStringToBytes(string hex)
        {
            if (hex == null || hex.Length % 2 != 0)
            {
                throw new PayNlException("Invalid hex string");
            }

            if (hex.Length == 0)
            {
                return Array.Empty<byte>();
            }

            var bytes = new byte[hex.Length / 2];
            for (var index = 0; index < bytes.Length; index++)
            {
                var byteValue = hex.Substring(index * 2, 2);
                bytes[index] = Convert.ToByte(byteValue, 16);
            }

            return bytes;
        }

        private static string NormalizeUuid(string uuid)
        {
            return Regex
                .Replace(uuid ?? string.Empty, UuidAllowedCharactersPattern, string.Empty, RegexOptions.IgnoreCase)
                .ToLowerInvariant();
        }

        private static string FormatUuid(string uuid)
        {
            return string.Join(
                "-",
                uuid.Substring(0, 8),
                uuid.Substring(8, 4),
                uuid.Substring(12, 4),
                uuid.Substring(16, 4),
                uuid.Substring(20, 12));
        }

        private static void ValidateSecret(string secret)
        {
            if (string.IsNullOrWhiteSpace(secret) || !Regex.IsMatch(secret, "^[0-9a-fA-F]{40}$"))
            {
                throw new PayNlException("Invalid secret");
            }
        }

        private static void ValidateServiceId(string serviceId)
        {
            if (string.IsNullOrWhiteSpace(serviceId) || !Regex.IsMatch(serviceId, "^SL-[0-9]{4}-[0-9]{4}$"))
            {
                throw new PayNlException("Invalid service ID");
            }
        }

        private static void ValidateReferenceString(string reference)
        {
            if (reference == null || !Regex.IsMatch(reference, "^[0-9a-zA-Z]{0,8}$"))
            {
                throw new PayNlException("Invalid reference: only alphanumeric chars are allowed, up to 8 chars long");
            }
        }

        private static void ValidateReferenceHex(string reference)
        {
            if (reference == null || !Regex.IsMatch(reference, "^[0-9a-fA-F]{0,16}$"))
            {
                throw new PayNlException("Invalid reference: only hexadecimal chars are allowed, up to 16 chars long");
            }
        }

        private static void ValidatePadChar(char padChar)
        {
            if (!Regex.IsMatch(new string(padChar, 1), "^[a-zA-Z0-9]{1}$"))
            {
                throw new PayNlException("Invalid pad char");
            }
        }
    }
}

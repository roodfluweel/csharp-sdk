using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Objects;

namespace PayNLSdk.API.DynamicUUID
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// original from : https://github.com/paynl/sdk/blob/e8b66a7d1b704be915189b03fa8d8b0c663fe0cb/src/DynamicUUID.php
    /// </remarks>
    public class DynamicUUID
    {
        private const int REFERENCE_TYPE_STRING = 1;
        private const int REFERENCE_TYPE_HEX = 0;

        private static readonly Encoding Encoding = Encoding.UTF8;

        /**
         * Generate a UUID
         *
         * @param string serviceId
         * @param string secret
         * @param string reference Your reference to the transaction
         * @param string padChar The reference will be padded with this character, default '0'
         * @param int referenceType Define if you are using a string (8 chars) of hex (16 chars)
         *
         * @return string The UUID
         */
        public string encode(string serviceId, string secret, string reference, char padChar = '0', int referenceType = REFERENCE_TYPE_STRING)
        {
            if (referenceType == REFERENCE_TYPE_STRING)
            {
                validateReferenceString(reference);
                reference = this.asciiToHex(reference);
            }
            else if (referenceType == REFERENCE_TYPE_HEX)
            {
                validateReferenceHex(reference);
            }
            validateSecret(secret);
            validateServiceId(serviceId);
            validatePadChar(padChar);
            var UUIDData = System.Text.RegularExpressions.Regex.Replace(serviceId, "/[^0-9]/", "");
            UUIDData += reference.ToLowerInvariant().PadLeft(16, padChar);

            var hash = MhmacSHA256(UUIDData, secret);
            var UUID = "b" + hash.Substring(0, 7) + UUIDData;
            return string.Format(
                "%08s-%04s-%04s-%04s-%12s",
                UUID.Substring(0, 8),
                UUID.Substring(8, 4),
                UUID.Substring(12, 4),
                UUID.Substring(16, 4),
                UUID.Substring(20, 12)
            );
        }

        #region new helper functions
        public static string MhmacSHA256(string key, string message)
        {
            var keyByte = Encoding.GetBytes(key);
            using (var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(Encoding.GetBytes(message));

                return ByteToString(hmacsha256.Hash);
            }
        }

        private static string ByteToString(byte[] buff)
        {
            var sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); /* hex format */
            }
            return sbinary;
        }

        // original from https://stackoverflow.com/a/29950264/97615
        private static string packHStar(string input)
        {
            //only for H32 & H*
            return Encoding.Default.GetString(FromHex(input));
        }

        // original from https://stackoverflow.com/a/29950264/97615
        private static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        // original from https://stackoverflow.com/a/29950264/97615
        private static string unpack(string p1, string input)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string a = Convert.ToInt32(input[i]).ToString("X");
                output.Append(a);
            }

            return output.ToString();
        }

        /// <summary>
        /// The equivalent for hexdec in php
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private static int HexToDec(String hex)
        {
            //Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            return Convert.ToInt32(hex, 16);
        }

        /// <summary>
        /// The equivalent for dechex in php
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        private static string DecToHex(int? decValue)
        {
            return decValue == null ? "" : decValue.Value.ToString("X");
        }

        #endregion

        private string asciiToHex(string ascii)
        {
            var hex = "";
            for (var i = 0; i < ascii.Length; i++)
            {
                var b = DecToHex((int)ascii[i]).ToUpper();
                b = new string('0', 2 - b.Length) + b;
                hex += b;
            }
            return hex;
        }

        private void validateSecret(string strSecret)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(strSecret, "/^[0-9a-f]{40}/", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new PayNlException("Invalid secret");
            }
        }
        private void validateServiceId(string strServiceId)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(strServiceId, "/^SL-[0-9]{4}-[0-9]{4}/"))
            {
                throw new PayNlException("Invalid service ID");
            }
        }
        private void validateReferenceString(string strReference)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(strReference, "/^[0-9a-zA-Z]{0,8}/", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new PayNlException("Invalid reference: only alphanumeric chars are allowed, up to 8 chars long");
            }
        }
        private void validateReferenceHex(string strReference)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(strReference, "/^[0-9a-f]{0,16}/", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new PayNlException("Invalid reference: only alphanumeric chars are allowed, up to 16 chars long");
            }
        }
        private void validatePadChar(char strPadChar)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(new string(new[] { strPadChar }), "/^[a-z0-9]{1}/", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new PayNlException("Invalid pad char");
            }
        }

        /**
         * Get url and qr-image for bancontact
         * @param UUID
         * @param withBase64 True if you need a base64 image
         * @return array url, QRUrl and QRBase64
         */
        public Dictionary<string, string> bancontact(string UUID, bool withBase64 = false)
        {
            string qrUrl = "https://chart.googleapis.com/chart?cht=qr&chs=260x260&chl=https://qr.pisp.me/bc/" + UUID;
            var result = new Dictionary<string, string>()
        {
            {"url" , "https://qr.pisp.me/bc/" + UUID},
            { "QRUrl" , qrUrl}

        };
            if (withBase64) result["QRBase64"] = base64_encode(file_get_contents(qrUrl));
            return result;
        }

        /**
         * Get url and qr-image for ideal
         *
         * @param UUID
         * @param withBase64 True if you need a base64 image
         * @return array url, QRUrl and QRBase64
         */
        public new Dictionary<string, string> ideal(string UUID, bool withBase64 = false)
        {
            var qrUrl = "https://ideal.pay.nl/qr/" + UUID;
            var result = new Dictionary<string, string>()
        {
            {"url" , "https://qr6.ideal.nl/" + UUID},
            { "QRUrl" , qrUrl}

        };

            if (withBase64) result["QRBase64"] = base64_encode(file_get_contents(qrUrl));
            return result;
        }

        /**
         * Decode a UUID
         *
         * @param string uuid The UUID to decode
         * @param string|null secret If supplied the uuid will be validated before decoding.
         * @param string padChar The reference will be padded with this character, default '0'
         *
         * @return array Array with serviceId and reference
         * @throws Error
         */
        public Dictionary<string, string> decode(string uuid, string secret = null, char padChar = '0', int referenceType = REFERENCE_TYPE_STRING)
        {
            if (string.IsNullOrWhiteSpace(secret) == false)
            {
                validateSecret(secret);
                var isValid = this.validate(uuid, secret);
                if (!isValid)
                {
                    throw new PayNlException("Incorrect signature");
                }
            }

            var uuidData = System.Text.RegularExpressions.Regex.Replace(uuid, "/[^0-9a-z]/", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            uuidData = uuidData.Substring(8);
            var serviceId = "SL-" + uuidData.Substring(0, 4) + '-' + uuidData.Substring(4, 4);
            var reference = uuidData.Substring(8);
            reference = reference.TrimStart(padChar); // trim leading characters
            if (referenceType == REFERENCE_TYPE_STRING)
            {
                reference = packHStar(reference);
            }

            return new Dictionary<string, string>{
            { "serviceId" , serviceId},
            { "reference", reference}
        };
        }

        /**
         * Validate a UUID with supplied secret
         *
         * @param string uuid
         * @param string secret
         *
         * @return bool
         */
        public bool validate(string uuid, string secret)
        {
            var uuidData = System.Text.RegularExpressions.Regex.Replace(uuid, "/[^0-9a-z]/", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            uuidData = uuidData.Substring(8);
            var hash = MhmacSHA256(secret, uuidData);
            var checksum = "b" + hash.Substring(0, 7);
            return checksum == uuid.Substring(0, 8);
        }
    }
}

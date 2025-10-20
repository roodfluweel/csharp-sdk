namespace PayNlSdk.API.DynamicUUID
{
    /// <summary>
    /// Contains QR-code information for Dynamic UUID payments.
    /// </summary>
    public sealed class DynamicUuidQrCodeInfo
    {
        public DynamicUuidQrCodeInfo(string url, string qrUrl, string qrBase64)
        {
            Url = url;
            QrUrl = qrUrl;
            QrBase64 = qrBase64;
        }

        /// <summary>
        /// Gets the payment URL that the QR-code points to.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the URL of the QR-code image.
        /// </summary>
        public string QrUrl { get; }

        /// <summary>
        /// Gets the base64 encoded QR-code image when requested.
        /// </summary>
        public string QrBase64 { get; }
    }
}

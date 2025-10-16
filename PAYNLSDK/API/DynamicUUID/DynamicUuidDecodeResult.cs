namespace PAYNLSDK.API.DynamicUUID
{
    /// <summary>
    /// Represents the decoded information from a Dynamic UUID.
    /// </summary>
    public sealed class DynamicUuidDecodeResult
    {
        public DynamicUuidDecodeResult(string serviceId, string reference)
        {
            ServiceId = serviceId;
            Reference = reference;
        }

        /// <summary>
        /// Gets the service id that was encoded in the UUID.
        /// </summary>
        public string ServiceId { get; }

        /// <summary>
        /// Gets the reference that was encoded in the UUID.
        /// </summary>
        public string Reference { get; }
    }
}

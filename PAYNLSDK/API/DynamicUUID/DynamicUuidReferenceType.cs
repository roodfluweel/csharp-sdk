namespace PayNlSdk.API.DynamicUUID
{
    /// <summary>
    /// Defines the reference type used when encoding or decoding Dynamic UUIDs.
    /// </summary>
    public enum DynamicUuidReferenceType
    {
        /// <summary>
        /// The reference is supplied in regular string form (maximum 8 characters).
        /// </summary>
        String,

        /// <summary>
        /// The reference is supplied in hexadecimal form (maximum 16 characters).
        /// </summary>
        Hex
    }
}

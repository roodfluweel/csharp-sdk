namespace PAYNLSDK.API.Alliance.Unsuspend
{
    /// <summary>
    /// Result class for Unsuspend call
    /// </summary>
    public class UnsuspendResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the merchant was successfully unsuspended
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

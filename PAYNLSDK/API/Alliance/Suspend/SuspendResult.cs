namespace PAYNLSDK.API.Alliance.Suspend
{
    /// <summary>
    /// Result class for Suspend call
    /// </summary>
    public class SuspendResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the merchant was successfully suspended
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

namespace PAYNLSDK.API.Alliance.MarkReady
{
    /// <summary>
    /// Result class for MarkReady call
    /// </summary>
    public class MarkReadyResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the merchant was successfully marked as ready
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

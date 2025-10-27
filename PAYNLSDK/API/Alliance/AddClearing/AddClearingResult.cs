namespace PAYNLSDK.API.Alliance.AddClearing
{
    /// <summary>
    /// Result class for AddClearing call
    /// </summary>
    public class AddClearingResult : ResponseBase
    {
        /// <summary>
        /// Returns true if clearing was successfully added
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

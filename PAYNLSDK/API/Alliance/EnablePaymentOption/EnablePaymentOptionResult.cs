namespace PAYNLSDK.API.Alliance.EnablePaymentOption
{
    /// <summary>
    /// Result class for EnablePaymentOption call
    /// </summary>
    public class EnablePaymentOptionResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the payment option was successfully enabled
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

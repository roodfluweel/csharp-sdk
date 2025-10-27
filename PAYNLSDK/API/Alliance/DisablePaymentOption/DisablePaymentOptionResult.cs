namespace PAYNLSDK.API.Alliance.DisablePaymentOption
{
    /// <summary>
    /// Result class for DisablePaymentOption call
    /// </summary>
    public class DisablePaymentOptionResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the payment option was successfully disabled
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}

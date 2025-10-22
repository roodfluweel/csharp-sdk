using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.AddBankAccount
{
    /// <summary>
    /// Result class for AddBankAccount call
    /// </summary>
    public class AddBankAccountResult : ResponseBase
    {
        /// <summary>
        /// The URL to redirect the user to for iDEAL verification
        /// </summary>
        [JsonProperty("issuerUrl")]
        public string IssuerUrl { get; set; }
    }
}

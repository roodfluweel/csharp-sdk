using System.Collections.Generic;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.GetAvailablePaymentOptions
{
    /// <summary>
    /// Result class for GetAvailablePaymentOptions call
    /// </summary>
    public class GetAvailablePaymentOptionsResult : ResponseBase
    {
        /// <summary>
        /// List of available payment options
        /// </summary>
        [JsonProperty("paymentOptions")]
        public List<PaymentOption> PaymentOptions { get; set; } = new List<PaymentOption>();
    }

    /// <summary>
    /// Payment option information
    /// </summary>
    public class PaymentOption
    {
        /// <summary>
        /// Payment option ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Payment option name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether the payment option is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}

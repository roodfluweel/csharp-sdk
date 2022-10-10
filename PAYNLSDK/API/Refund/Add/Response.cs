using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.Refund.Add
{
    /// <summary>
    /// The response of a Refund Add call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the refund starting with 'RF-' (optional, emptyfor creditcard transactions)
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

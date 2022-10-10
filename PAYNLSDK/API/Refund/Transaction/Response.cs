using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Refund.Transaction
{
    /// <summary>
    /// The response of a refund transaction call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the refund starting with 'RF-' (optional, empty for creditcard transactions)
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

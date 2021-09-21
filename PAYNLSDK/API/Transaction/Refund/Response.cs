using Newtonsoft.Json;
using System;

namespace PayNLSdk.API.Transaction.Refund
{
    /// <summary>
    /// The response of a refund call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The ID of the refund transaction
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; protected set; }
    }
}

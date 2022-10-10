using Newtonsoft.Json;
using System;

namespace PayNLSdk.API.Transaction.Refund
{
    /// <summary>
    /// Response of a transaction refund call
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

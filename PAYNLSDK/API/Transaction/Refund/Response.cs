using Newtonsoft.Json;
using System;

namespace PAYNLSDK.API.Transaction.Refund
{
    /// <summary>
    /// Response of a transaction refund call
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("refundId")]
        public string RefundId { get; protected set; }
    }
}

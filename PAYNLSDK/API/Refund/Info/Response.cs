using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Refund.Info
{
    /// <summary>
    /// The response of a Refund info Call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// Refund information
        /// </summary>
        [JsonProperty("refund")]
        public RefundInfo Refund { get; protected set; }
    }
}

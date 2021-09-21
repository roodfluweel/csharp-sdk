using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Refund.Info
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// Refund information
        /// </summary>
        [JsonProperty("refund")]
        public RefundInfo Refund { get; protected set; }
    }
}

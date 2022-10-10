using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.SMS.PremiumMessage
{
    /// <summary>
    /// The response of a SMS PremiumMessage Call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// True if the call was successful
        /// </summary>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

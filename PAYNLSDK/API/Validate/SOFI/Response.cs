using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.SOFI
{
    /// <summary>
    /// The response of a Validate SOFI Call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The result, true if successful
        /// </summary>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

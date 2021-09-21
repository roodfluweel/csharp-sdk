using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.SMS.PremiumMessage
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

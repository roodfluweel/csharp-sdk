using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.Validate.SOFI
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

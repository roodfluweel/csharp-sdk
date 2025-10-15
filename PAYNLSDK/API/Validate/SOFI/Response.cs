using Newtonsoft.Json;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.Validate.SOFI;

public class Response : ResponseBase
{
    [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

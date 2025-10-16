using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Converters;

namespace PayNlSdk.Api.Validate.SOFI;

public class Response : ResponseBase
{
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

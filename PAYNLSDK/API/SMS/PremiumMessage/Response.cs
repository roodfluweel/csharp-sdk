using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.SMS.PremiumMessage;

public class Response : ResponseBase
{
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

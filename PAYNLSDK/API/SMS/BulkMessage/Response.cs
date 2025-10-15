using Newtonsoft.Json;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.SMS.BulkMessage;

public class Response : ResponseBase
{
    [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

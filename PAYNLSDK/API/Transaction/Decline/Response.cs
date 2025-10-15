using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Transaction.Decline;

public class Response : ResponseBase
{
    [JsonPropertyName("message")]
    public string Message { get; protected set; }
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Transaction.Decline;

public class Response : ResponseBase
{
    [JsonPropertyName("message")]
    public string Message { get; protected set; }
}

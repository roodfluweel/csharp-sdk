using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Transaction.Approve;

public class Response : ResponseBase
{

    [JsonPropertyName("message")]
    public string Message { get; protected set; }
}
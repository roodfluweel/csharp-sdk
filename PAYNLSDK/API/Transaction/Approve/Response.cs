using Newtonsoft.Json;

namespace PayNLSdk.Api.Transaction.Approve;

public class Response : ResponseBase
{

    [JsonProperty("message")]
    public string Message { get; protected set; }
}
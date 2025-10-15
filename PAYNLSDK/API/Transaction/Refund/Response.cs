using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Transaction.Refund;

public class Response : ResponseBase
{
    [JsonPropertyName("refundId")]
    public string RefundId { get; protected set; }
}

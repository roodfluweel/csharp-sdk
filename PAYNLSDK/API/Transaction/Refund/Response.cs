using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Transaction.Refund;

public class Response : ResponseBase
{
    [JsonPropertyName("refundId")]
    public string? RefundId { get; set; }
}

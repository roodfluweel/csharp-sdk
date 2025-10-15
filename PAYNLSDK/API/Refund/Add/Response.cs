using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Refund.Add;

public class Response : ResponseBase
{
    /// <summary>
    /// ID of the refund starting with 'RF-' (optional, emptyfor creditcard transactions)
    /// </summary>
    [JsonPropertyName("refundId")]
    public string RefundId { get; set; }
}

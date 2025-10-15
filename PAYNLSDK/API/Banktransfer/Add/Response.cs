using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Banktransfer.Add;

public class Response : ResponseBase
{
    [JsonPropertyName("refundId")]
    public string RefundId { get; set; }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Objects;

namespace PayNLSdk.Api.Refund.Info;

public class Response : ResponseBase
{
    /// <summary>
    /// Refund information
    /// </summary>
    [JsonPropertyName("refund")]
    public RefundInfo Refund { get; protected set; }
}

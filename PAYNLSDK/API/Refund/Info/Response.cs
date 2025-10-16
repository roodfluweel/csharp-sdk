using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Objects;

namespace PayNlSdk.Api.Refund.Info;

public class Response : ResponseBase
{
    /// <summary>
    /// Refund information
    /// </summary>
    [JsonPropertyName("refund")]
    public RefundInfo Refund { get; protected set; }
}

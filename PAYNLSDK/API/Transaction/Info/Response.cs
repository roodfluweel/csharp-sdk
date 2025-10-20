using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Objects;

namespace PayNlSdk.Api.Transaction.Info;

public class Response : ResponseBase
{
    [JsonPropertyName("connection")]
    public Connection? Connection { get; set; }

    [JsonPropertyName("enduser")]
    public EndUser? EndUser { get; set; }

    //[JsonPropertyName("saledata")]
    //public SalesData SalesData { get; set; }

    /// <summary>
    /// All details from the payment
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetails? PaymentDetails { get; set; }

    /// <summary>
    /// Details regarding the refund (if any)
    /// </summary>
    [JsonPropertyName("stornoDetails")]
    public StornoDetails? StornoDetails { get; set; }

    [JsonPropertyName("statsDetails")]
    public StatsDetails? StatsDetails { get; set; }

}

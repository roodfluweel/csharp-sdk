using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Objects;

namespace PayNlSdk.Api.Transaction.Info;

public class Response : ResponseBase
{
    [JsonPropertyName("connection")]
    public Connection Connection { get; protected set; }

    [JsonPropertyName("enduser")]
    public EndUser EndUser { get; protected set; }

    //[JsonPropertyName("saledata")]
    //public SalesData SalesData { get; protected set; }

    /// <summary>
    /// All details from the payment
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetails PaymentDetails { get; protected set; }

    /// <summary>
    /// Details regarding the refund (if any)
    /// </summary>
    [JsonPropertyName("stornoDetails")]
    public StornoDetails StornoDetails { get; protected set; }

    [JsonPropertyName("statsDetails")]
    public StatsDetails StatsDetails { get; protected set; }

}

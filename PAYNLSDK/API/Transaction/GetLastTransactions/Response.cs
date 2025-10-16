using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Objects;

namespace PayNlSdk.Api.Transaction.GetLastTransactions;

public class Response : ResponseBase
{
    [JsonPropertyName("arrStatsData")]
    public TransactionStatsList TransactionStats { get; set; }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Objects;

namespace PayNLSdk.Api.Transaction.GetLastTransactions;

public class Response : ResponseBase
{
    [JsonPropertyName("arrStatsData")]
    public TransactionStatsList TransactionStats { get; set; }
}

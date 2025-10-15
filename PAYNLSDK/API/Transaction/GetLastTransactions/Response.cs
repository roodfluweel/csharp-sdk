using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.Api.Transaction.GetLastTransactions;

public class Response : ResponseBase
{
    [JsonProperty("arrStatsData")]
    public TransactionStatsList TransactionStats { get; set; }
}

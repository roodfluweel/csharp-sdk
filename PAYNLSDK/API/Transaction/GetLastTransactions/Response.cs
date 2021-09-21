using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Transaction.GetLastTransactions
{
    public class Response : ResponseBase
    {
        [JsonProperty("arrStatsData")]
        public TransactionStatsList TransactionStats { get; set; }
    }
}

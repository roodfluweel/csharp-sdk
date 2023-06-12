using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Transaction.GetLastTransactions
{
    /// <summary>
    /// The response of a Transaction GetLastTransactions Call
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("arrStatsData")]
        public TransactionStatsList TransactionStats { get; set; }
    }
}

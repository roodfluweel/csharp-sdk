using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.GetLastTransactions
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

using Newtonsoft.Json;
using System;

namespace PAYNLSDK.API.Transaction.Approve
{
    /// <summary>
    /// Response of a Transaction Approve call
    /// </summary>
    public class Response : ResponseBase
    {

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}

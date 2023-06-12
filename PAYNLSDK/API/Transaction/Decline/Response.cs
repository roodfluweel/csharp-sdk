using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.Transaction.Decline
{
    /// <summary>
    /// Response of a Transaction Decline call
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}

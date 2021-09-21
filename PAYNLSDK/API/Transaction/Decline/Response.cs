using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.Transaction.Decline
{
    public class Response : ResponseBase
    {
        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}

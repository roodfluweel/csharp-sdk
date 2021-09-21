using Newtonsoft.Json;
using System;

namespace PayNLSdk.API.Transaction.Approve
{
    public class Response : ResponseBase
    {

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}

using Newtonsoft.Json;
using System;

namespace PayNLSdk.API.Transaction.Approve
{
    /// <summary>
    /// Response of a Transaction Approve call
    /// </summary>
    public class Response : ResponseBase
    {

        /// <summary>
        /// The result data
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}

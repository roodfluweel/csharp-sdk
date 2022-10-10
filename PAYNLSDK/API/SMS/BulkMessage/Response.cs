using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayNLSdk.API.SMS.BulkMessage
{
    /// <summary>
    /// The request data for the SMS BulkMessage call
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("result"),JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

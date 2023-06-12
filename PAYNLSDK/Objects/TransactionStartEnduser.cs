using Newtonsoft.Json;
using PayNLSdk.Converters;
using PayNLSdk.Enums;
using System;

namespace PayNLSdk.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionStartEnduser
    {
        /// <summary>
        /// Indidicator whether or not the cusomer is blacklisted
        /// </summary>
        [JsonProperty("blacklist")]
        public Blacklist Blacklist {get; protected set;}
    }

}

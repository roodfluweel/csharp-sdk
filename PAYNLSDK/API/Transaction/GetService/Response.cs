using System;
using PayNLSdk.API;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Transaction.GetService
{
    /// <summary>
    /// The response data for the Transaction GetService call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The merchant
        /// </summary>
        [JsonProperty("merchant")]
        public Objects.Merchant Merchant { get; set; }

        /// <summary>
        /// The service
        /// </summary>
        [JsonProperty("service")]
        public PayNLSdk.Objects.Service Service { get; set; }

        /// <summary>
        /// the country options
        /// </summary>
        [JsonProperty("countryOptionList")]
        public CountryOptions CountryOptions { get; set; }
    }
}

using System;
using PayNLSdk.API;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Transaction.GetService
{
    public class Response : ResponseBase
    {
        [JsonProperty("merchant")]
        public Objects.Merchant Merchant { get; set; }

        [JsonProperty("service")]
        public PayNLSdk.Objects.Service Service { get; set; }

        [JsonProperty("countryOptionList")]
        public CountryOptions CountryOptions { get; set; }
    }
}

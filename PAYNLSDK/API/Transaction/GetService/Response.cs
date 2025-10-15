using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.Api.Transaction.GetService;

public class Response : ResponseBase
{
    [JsonProperty("merchant")]
    public Objects.Merchant Merchant { get; set; }

    [JsonProperty("service")]
    public Objects.Service Service { get; set; }

    [JsonProperty("countryOptionList")]
    public CountryOptions CountryOptions { get; set; }
}

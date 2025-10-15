using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Objects;

namespace PayNLSdk.Api.Transaction.GetService;

public class Response : ResponseBase
{
    [JsonPropertyName("merchant")]
    public Objects.Merchant Merchant { get; set; }

    [JsonPropertyName("service")]
    public Objects.Service Service { get; set; }

    [JsonPropertyName("countryOptionList")]
    public CountryOptions CountryOptions { get; set; }
}

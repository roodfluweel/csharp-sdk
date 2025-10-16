using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Objects;

/// <summary>
/// Company information, used in the enduser.
/// </summary>
public class Company
{
    /// <summary>
    /// The name of the company
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The COC number of the company
    /// </summary>
    [JsonPropertyName("cocNumber")]
    public string CocNumber { get; set; }

    /// <summary>
    /// The VAT number of the company
    /// </summary>
    [JsonPropertyName("vatNumber")]
    public string VatNumber { get; set; }

    /// <summary>
    /// ID of the country (2 char country code)
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}

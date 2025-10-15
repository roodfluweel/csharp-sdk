using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;
using PayNLSdk.Enums;

namespace PayNLSdk.Objects;

/// <summary>
/// General Address Details
/// </summary>
public class Address
{
    /// <summary>
    /// Initials for Address
    /// </summary>
    [JsonPropertyName("initials")]
    public string Initials { get; set; }

    /// <summary>
    /// Lastname of receiver
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gender of receiver
    /// </summary>
    [JsonPropertyName("gender"), JsonConverter(typeof(GenderConverter))]
    public Gender? Gender { get; set; }

    /// <summary>
    /// Street name
    /// </summary>
    [JsonPropertyName("streetName")]
    public string StreetName { get; set; }

    /// <summary>
    /// Street number
    /// </summary>
    [JsonPropertyName("streetNumber")]
    public string StreetNumber { get; set; }

    /// <summary>
    /// Street number
    /// </summary>
    [JsonPropertyName("streetNumberExtension")]
    public string StreetNumberExtension { get; set; }

    /// <summary>
    /// Zipcode
    /// </summary>
    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; }

    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; }

    /// <summary>
    /// ISO2 Country code
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Objects;

/// <summary>
/// Payment Method information
/// </summary>
public class PaymentMethod
{
    /// <summary>
    /// Payment method ID
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Payment method name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Abbreviation for this payment method
    /// </summary>
    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; }

}

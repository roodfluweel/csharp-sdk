using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Enums;

namespace PayNlSdk.Objects;

/// <summary>
/// Merchant information
/// </summary>
public class Merchant
{
    /// <summary>
    /// Merchant ID
    /// </summary>
    [JsonPropertyName("id")]
    public string ID { get; set; }

    /// <summary>
    /// Merchant Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Merchant Public Name
    /// </summary>
    [JsonPropertyName("publicName")]
    public string PublicName { get; set; }

    /// <summary>
    /// Active State of the merchant
    /// </summary>
    [JsonPropertyName("state")]
    public ActiveState State { get; set; }

}
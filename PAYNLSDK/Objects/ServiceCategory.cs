using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Objects;

/// <summary>
/// Service Category information
/// </summary>
public class ServiceCategory
{
    /// <summary>
    /// ID of the Service Category
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Name of the Service Category
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

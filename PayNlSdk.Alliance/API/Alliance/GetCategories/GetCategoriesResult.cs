using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetCategories;

/// <summary>
/// Response payload that contains category information for services.
/// </summary>
public class GetCategoriesResult : ResponseBase
{
    /// <summary>
    /// Available categories.
    /// </summary>
    [JsonPropertyName("categories")]
    public IReadOnlyList<Category>? Categories { get; set; }

    /// <summary>
    /// Single category representation.
    /// </summary>
    public class Category
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
    }
}

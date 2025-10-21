using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.Document.Add;

/// <summary>
/// Response returned after uploading one or multiple document files through the Alliance endpoint.
/// </summary>
public class Response : ResponseBase
{
    /// <summary>
    /// Indicates success.
    /// </summary>
    [JsonPropertyName("result")]
    public bool Result { get; set; }

    /// <summary>
    /// Error code when <see cref="Result"/> is <c>false</c>.
    /// </summary>
    [JsonPropertyName("errorId")]
    public string? ErrorId { get; set; }

    /// <summary>
    /// Description of the error when <see cref="Result"/> is <c>false</c>.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Document.Add;

/// <summary>
/// The result whether the Upload of one or multiple files to a document for a merchant or account has completed
/// </summary>
public class Response : ResponseBase
{
    /// <summary>
    /// If true the call was successful
    /// </summary>
    [JsonPropertyName("result")] public bool Result { get; set; }

    /// <summary>
    /// ID of the error (if an error occurred)
    /// </summary>
    [JsonPropertyName("errorId")] public string ErrorId { get; set; }

    /// <summary>
    /// Description of the error (if an error occurred)
    /// </summary>
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
}
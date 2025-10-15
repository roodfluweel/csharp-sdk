using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;

namespace PayNLSdk.Objects;

/// <summary>
/// Error definition
/// </summary>
public class Error
{
    /// <summary>
    /// Result of a call. In case of a real error, this SHOULD always be false.
    /// </summary>
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    public bool Result { get; protected set; }

    /// <summary>
    /// Error code
    /// </summary>
    [JsonPropertyName("errorId")]
    public string Code { get; protected set; }

    /// <summary>
    /// Error message
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string Message { get; protected set; }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Converters;

namespace PayNlSdk.Api.Validate.SWIFT;

/// <summary>
/// Response of the <see cref="Request"/>.
/// Implements the <see cref="ResponseBase" />
/// </summary>
/// <seealso cref="ResponseBase" />
public class Response : ResponseBase
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Response"/> is successful.
    /// </summary>
    /// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}
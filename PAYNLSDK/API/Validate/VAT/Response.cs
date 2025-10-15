using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.Validate.VAT;

/// <summary>
/// Reponse of the <see cref="Request"/>.
/// Implements the <see cref="ResponseBase" />
/// </summary>
/// <seealso cref="ResponseBase" />
public class Response : ResponseBase
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Response"/> is succesful.
    /// </summary>
    /// <value><c>true</c> if succesful; otherwise, <c>false</c>.</value>
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

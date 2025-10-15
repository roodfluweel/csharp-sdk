using Newtonsoft.Json;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.Validate.SWIFT;

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
    [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}
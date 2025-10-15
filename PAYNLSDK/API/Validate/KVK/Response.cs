using Newtonsoft.Json;
using PayNLSdk.Converters;

namespace PayNLSdk.Api.Validate.KVK;

/// <summary>
/// The response object for <see cref="Request"/>
/// Implements the <see cref="ResponseBase" />
/// </summary>
/// <seealso cref="ResponseBase" />
/// <inheritdoc />
public class Response : ResponseBase
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Response"/> is result.
    /// </summary>
    /// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
    [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
    public bool result { get; protected set; }
}

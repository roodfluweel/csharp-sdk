using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Utilities;
using PayNLSdk.Objects;

namespace PayNLSdk.Api;

/// <summary>
/// A abstract base class for every response from the API
/// </summary>
public abstract class ResponseBase
{
    /// <summary>
    /// The Error if the request led to a failed response
    /// </summary>
    [JsonPropertyName("request")]
    public Error Request { get; protected set; }

    /// <summary>
    /// Return response as formatted JSON
    /// </summary>
    /// <returns>JSON string</returns>
    public override string ToString()
    {
        //return base.ToString();
        return JsonSerialization.Serialize(this, JsonSerialization.CreateIndentedOptions());
    }
}

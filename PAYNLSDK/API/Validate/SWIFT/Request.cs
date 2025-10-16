using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Api.Validate.SWIFT;

/// <summary>
/// Request to validate a swift number.
/// Implements the <see cref="RequestBase" />
/// </summary>
/// <inheritdoc />
/// <seealso cref="RequestBase" />
public class Request : RequestBase
{
    /// <summary>
    /// Gets or sets the SWIFT number.
    /// </summary>
    /// <value>The swift.</value>
    [JsonPropertyName("swift")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public string SWIFT { get; set; }

    /// <inheritdoc />
    public override bool RequiresApiToken => false;

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "Validate";

    /// <inheritdoc />
    protected override string Method => "SWIFT";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(SWIFT, "swift");
        nvc.Add("swift", SWIFT);

        return nvc;
    }

    /// <summary>
    /// Gets the response.
    /// </summary>
    /// <value>The response.</value>
    public Response Response => (Response)response;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonSerialization.Deserialize<Response>(RawResponse);
    }
}

using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.Api.Validate.SWIFT;

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
    [JsonProperty("swift")]
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
        response = JsonConvert.DeserializeObject<Response>(RawResponse);
    }
}

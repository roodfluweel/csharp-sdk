using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.Api.Validate.VAT;

/// <summary>
/// A request to validate a VAT number
/// Implements the <see cref="RequestBase" />
/// </summary>
/// <inheritdoc />
/// <seealso cref="RequestBase" />
public class Request : RequestBase
{
    /// <summary>
    /// Gets or sets the vat.
    /// </summary>
    /// <value>The vat.</value>
    [JsonProperty("vat")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public string VAT { get; set; }

    /// <inheritdoc />
    public override bool RequiresApiToken => false;// base.RequiresApiToken;

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "Validate";

    /// <inheritdoc />
    protected override string Method => "VAT";

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        var nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(VAT, "vat");
        nvc.Add("vat", VAT);

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
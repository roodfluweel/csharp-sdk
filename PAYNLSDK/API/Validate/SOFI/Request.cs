using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.Validate.SOFI;

public class Request : RequestBase
{
    [JsonPropertyName("sofi")]
    public string SOFI { get; set; }

    public override bool RequiresApiToken
    {
        get
        {
            return false;// base.RequiresApiToken;
        }
    }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "Validate";

    /// <inheritdoc />
    protected override string Method => "SOFI";

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(SOFI, "sofi");
        nvc.Add("sofi", SOFI);

        return nvc;
    }

    public Response Response { get { return (Response)response; } }

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

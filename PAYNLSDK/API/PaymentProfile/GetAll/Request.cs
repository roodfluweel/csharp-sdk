using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.PaymentProfile.GetAll;

public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "PaymentProfile";

    /// <inheritdoc />
    protected override string Method => "getAll";

    public override NameValueCollection GetParameters()
    {
        return new NameValueCollection();
    }

    public Response Response => (Response)response;

    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        Objects.PaymentProfile[] pm = JsonSerialization.Deserialize<Objects.PaymentProfile[]>(RawResponse);
        Response r = new Response
        {
            PaymentProfiles = pm
        };
        response = r;
    }
}

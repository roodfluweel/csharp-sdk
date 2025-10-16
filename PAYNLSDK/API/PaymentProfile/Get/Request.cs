using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.PaymentProfile.Get;

public class Request : RequestBase
{

    [JsonPropertyName("paymentProfileId")]
    public int PaymentProfileId { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "PaymentProfile";

    /// <inheritdoc />
    protected override string Method => "get";

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotNull(PaymentProfileId, "PaymentProfileId");
        nvc.Add("paymentProfileId", PaymentProfileId.ToString());

        return nvc;
    }

    public Response Response => (Response)response;


    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        Objects.PaymentProfile pm = JsonSerialization.Deserialize<Objects.PaymentProfile>(RawResponse);
        Response r = new Response
        {
            PaymentProfile = pm
        };
        response = r;
    }
}

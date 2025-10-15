using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.PaymentProfile.Get;

public class Request : RequestBase
{

    [JsonProperty("paymentProfileId")]
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
        Objects.PaymentProfile pm = JsonConvert.DeserializeObject<Objects.PaymentProfile>(RawResponse);
        Response r = new Response
        {
            PaymentProfile = pm
        };
        response = r;
    }
}

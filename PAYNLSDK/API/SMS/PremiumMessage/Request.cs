using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.SMS.PremiumMessage;

public class Request : RequestBase
{

    [JsonProperty("sms_id")]
    public string SmsId { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "SMS";

    /// <inheritdoc />
    protected override string Method => "sendPremiumMessage";

    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(SmsId, "SmsId");
        nvc.Add("sms_id", SmsId);

        ParameterValidator.IsNotEmpty(Secret, "secret");
        nvc.Add("secret", Secret);

        ParameterValidator.IsNotEmpty(Message, "message");
        nvc.Add("message", Message);

        return nvc;
    }
    public Response Response => (Response)response;

    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonConvert.DeserializeObject<Response>(RawResponse);
    }

}

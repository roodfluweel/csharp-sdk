using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.SMS.PremiumMessage;

public class Request : RequestBase
{

    [JsonPropertyName("sms_id")]
    public string SmsId { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("message")]
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
        response = JsonSerialization.Deserialize<Response>(RawResponse);
    }

}

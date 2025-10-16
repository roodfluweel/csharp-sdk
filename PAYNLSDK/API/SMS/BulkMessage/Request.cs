using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.SMS.BulkMessage;

public class Request : RequestBase
{
    [JsonPropertyName("org")]
    public string Sender { get; set; }

    [JsonPropertyName("dest")]
    public string Recipient { get; set; }

    [JsonPropertyName("body")]
    public string Message { get; set; }

    //[JsonPropertyName("starttime")]
    //public int SendTime { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "SMS";

    /// <inheritdoc />
    protected override string Method => "sendBulkMessage";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(Sender, "Sender");
        nvc.Add("org", Sender);

        ParameterValidator.IsNotEmpty(Recipient, "Recipient");
        nvc.Add("dest", Recipient);

        ParameterValidator.IsNotEmpty(Message, "Message");
        nvc.Add("body", Message);

        return nvc;
    }
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

using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Merchant.Info;

public class Request : RequestBase
{
    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    /// <inheritdoc />
    protected override int Version { get; }
    /// <inheritdoc />
    protected override string Controller => "Merchant";
    /// <inheritdoc />
    protected override string Method => "info";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var nvc = new NameValueCollection();
        nvc.Add("merchantId", MerchantId);

        return nvc;
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonSerialization.Deserialize<PayNlSdk.Api.Merchant.Info.Response>(RawResponse);
        if (response == null)
        {
            throw new PayNlException("Failed to deserialize response");
        }
        var merchantResponse = response as PayNlSdk.Api.Merchant.Info.Response;

        // Check if request was successful (result should be true for success)
        if (merchantResponse?.Request != null && !merchantResponse.Request.Result)
        {
            // toss
            var errorMessage = !string.IsNullOrEmpty(merchantResponse.Request.Message)
                ? merchantResponse.Request.Message
                : "Request failed";
            throw new PayNlException(errorMessage);
        }
    }
}

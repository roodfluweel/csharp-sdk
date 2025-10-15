using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Merchant.Info;

public class Request : RequestBase
{
    [JsonProperty("merchantId")]
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
        response = JsonConvert.DeserializeObject<Response>(RawResponse);
        if (!response.Request.Result)
        {
            // toss
            throw new PayNlException(response.Request.Message);
        }
    }
}

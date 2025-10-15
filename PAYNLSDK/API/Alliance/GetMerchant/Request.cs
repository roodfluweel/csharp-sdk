using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Alliance.GetMerchant;

public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;
    /// <inheritdoc />
    protected override string Controller => "Alliance";
    /// <inheritdoc />
    protected override string Method => "getMerchant";

    /// <summary>
    /// the merchant Id to request
    /// </summary>
    public string MerchantId { get; set; }

    public override NameValueCollection GetParameters()
    {
        var retval = new NameValueCollection { { "merchantId", MerchantId } };
        return retval;
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        // response = JsonConvert.DeserializeObject<GetMerchantResult>(RawResponse);

    }
}
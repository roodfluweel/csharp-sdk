using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Merchant.Info;

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
            response = JsonConvert.DeserializeObject<API.Merchant.Get.Response>(RawResponse);
            var merchantResponse = response as API.Merchant.Get.Response;
            
            // Check if request was successful (result can be "1" for success or other values for failure)
            if (merchantResponse?.request != null && merchantResponse.request.result != "1")
            {
                // toss
                var errorMessage = !string.IsNullOrEmpty(merchantResponse.request.errorMessage) 
                    ? merchantResponse.request.errorMessage 
                    : "Request failed";
                throw new PayNlException(errorMessage);
            }
        }
    }
}

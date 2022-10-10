using PAYNLSDK.API.Merchant.Add;
using PAYNLSDK.API.Merchant.Get;

namespace PAYNLSDK
{
    /// <summary>
    /// The interface with the all the methods to be called on the merchant.
    /// Register this interface in your DI container with the <see cref="Merchant"/> implementation
    /// </summary>
    public interface IMerchant
    {
        API.Merchant.Add.Response Create(API.Merchant.Add.Request request);
        API.Merchant.Get.Response Get(string merchantId);
        PayNLSdk.API.Merchant.Clearing.Response AddClearing(PayNLSdk.API.Merchant.Clearing.Request request);
    }
}

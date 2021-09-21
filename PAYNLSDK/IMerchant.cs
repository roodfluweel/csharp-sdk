using PayNLSdk.API.Merchant.Add;
using PayNLSdk.API.Merchant.Get;

namespace PayNLSdk
{
    public interface IMerchant
    {
        API.Merchant.Add.Response Create(API.Merchant.Add.Request request);
        API.Merchant.Get.Response Get(string merchantId);
    }
}
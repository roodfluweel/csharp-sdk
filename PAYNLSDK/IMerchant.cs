using PayNLSdk.API.Merchant.Add;
using Response = PayNLSdk.API.Merchant.Info.Response;

namespace PayNLSdk
{
    public interface IMerchant
    {
        API.Merchant.Add.Response Create(API.Merchant.Add.Request request);
        Response Get(string merchantId);
    }
}

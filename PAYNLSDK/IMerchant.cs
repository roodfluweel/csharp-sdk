using PayNlSdk.Api.Merchant.Add;

namespace PayNlSdk;

public interface IMerchant
{
    Response Create(Request request);
    Api.Merchant.Info.Response Get(string merchantId);
    Api.Merchant.Clearing.Response AddClearing(Api.Merchant.Clearing.Request request);
}

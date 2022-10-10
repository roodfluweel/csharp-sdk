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
        /// <summary>Create a new merchant</summary>
        /// <remarks></remarks>
        /// <returns>A new <see cref="API.Merchant.Add.Response"/> object</returns>
        API.Merchant.Add.Response Create(API.Merchant.Add.Request request);

        /// <summary>
        /// Get a specific merchant by id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        API.Merchant.Get.Response Get(string merchantId);

        /// <summary>
        /// Add a clearing for a particular merchant for a certain amount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PayNLSdk.API.Merchant.Clearing.Response AddClearing(PayNLSdk.API.Merchant.Clearing.Request request);

        /// <summary>
        /// Get a list of all merchants
        /// </summary>
        object GetAll( /*options = array()*/);
    }
}

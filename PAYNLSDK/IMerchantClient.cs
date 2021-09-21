using System;

namespace PayNLSdk
{
    [Obsolete("Use IMerchantClient()", true)]
    public interface IMerchant
    {
    }


    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantClient
    {
        /// <summary>
        /// Get the details of a merchant
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        PayNLSdk.API.Merchant.Info.Response Get(string merchantId);
    }
}

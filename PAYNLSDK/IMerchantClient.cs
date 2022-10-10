using System;

namespace PayNLSdk
{
    [Obsolete("Use IMerchantClient", true)]
    public interface IMerchant
    {
    }


    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantClient
    {

        /// <summary>Create a new merchant</summary>
        /// <remarks></remarks>
        /// <returns>A new <see cref="API.Merchant.Add.Response"/> object</returns>
        [Obsolete("Use AllianceClient.AddMerchant()", true)]
        object Create(object request);

        /// <summary>
        /// Get the details of a merchant
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        API.Merchant.Info.Response Get(string merchantId);

        /// <summary>
        /// Add a clearing for a particular merchant for a certain amount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        API.Merchant.Clearing.Response AddClearing(PayNLSdk.API.Merchant.Clearing.Request request);

        /// <summary>
        /// Get a list of all merchants
        /// </summary>
        object GetAll( /*options = array()*/);


    }
}

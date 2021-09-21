using PayNLSdk.Net;
using System;

namespace PayNLSdk
{
    [Obsolete("Use class MerchantClient", true)]
    public class Merchant
    {
    }

    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class MerchantClient : IMerchantClient
    {
        private readonly IClient _webClient;

        /// <summary>
        /// The merchant api. This is a part from the alliance SDK.
        /// </summary>
        /// <param name="webClient"></param>
        public MerchantClient(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// obsolete, use the alliance SDK
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Obsolete("Use AllianceClient.AddMerchant()", true)]
        public object Create(object request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a specific merchant by id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public API.Merchant.Info.Response Get(string merchantId)
        {
            //api = new Api\GetMerchant();
            //   if (!String.IsNullOrEmpty( options['merchantId']))
            //   {
            //    api->setMerchantId( options['merchantId']);
            //   }

            //result =  api->doRequest();

            var request = new API.Merchant.Info.Request
            {
                MerchantId = merchantId
            };

            var response = _webClient.PerformRequest(request);
            return API.Merchant.Info.Response.FromRawResponse(response);
        }

        /// <summary>
        /// Get a list of all merchants
        /// </summary>
        public object GetAll( /*options = array()*/)
        {
            throw new NotImplementedException("this is not yet implemented");
            //api = new Api\GetMerchants();

            //   if (!String.IsNullOrEmpty( options['state']))
            //   {
            //    api->setState( options['state']);
            //   }


            //var request = new API.Merchant.GetAll.Request
            //{
            //    MerchantId = "TODO"
            //};

            //var response = _webClient.PerformRequest(request);
            //return API.Merchant.GetAll.Response.FromRawResponse(response);

            //return new object(); // Result\Merchant\GetList( result);
        }

        public enum MerchantState
        {
            NewMerchant,

        }
    }
}

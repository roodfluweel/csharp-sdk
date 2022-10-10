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

        /// <inheritdoc />
        [Obsolete("Use AllianceClient.AddMerchant()", true)]
        public object Create(object request)
        {
            throw new NotImplementedException();
        }
        
         /// <inheritdoc />
        public PayNLSdk.API.Merchant.Clearing.Response AddClearing(PayNLSdk.API.Merchant.Clearing.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return PayNLSdk.API.Merchant.Clearing.Response.FromRawResponse(response);
        }

        /// <inheritdoc />
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

        /// <summary>
        /// The state of the merchant
        /// </summary>
        public enum MerchantState
        {
            /// <summary>
            /// a new merchant
            /// </summary>
            NewMerchant,

        }
    }
}

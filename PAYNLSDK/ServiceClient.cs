using PayNLSdk.Enums;
using PayNLSdk.Net;
using System;
using ServiceGetCategories = PayNLSdk.API.Service.GetCategories.Request;

namespace PayNLSdk
{
    [Obsolete("use class ServiceClient()", true)]
#pragma warning disable 1591
    public class Service
    {
    }
#pragma warning restore 1591

    /// <summary>
    /// Service endpoint helper class.
    /// Makes calling PAYNL Services easier and eliminates the need to fully initiate all Request objects.
    /// </summary>
    public class ServiceClient : IServiceClient
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Creates a new instance for the ServiceClient
        /// </summary>
        /// <param name="webClient"></param>
        public ServiceClient(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// Get Service Categories for a given payment option ID
        /// </summary>
        /// <param name="paymentOptionId">Payment Option ID, if null return all</param>
        /// <returns>Response object containing service categories</returns>
        public PayNLSdk.API.Service.GetCategories.Response GetCategories(int? paymentOptionId = null)
        {
            var request = new ServiceGetCategories
            {
                PaymentOptionId = paymentOptionId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }
    }
}

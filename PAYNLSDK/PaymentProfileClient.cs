using System;
using PayNLSdk.Net;
using PaymentProfileGet = PayNLSdk.API.PaymentProfile.Get.Request;
using PaymentProfileGetAll = PayNLSdk.API.PaymentProfile.GetAll.Request;
using PaymentProfileGetAvailable = PayNLSdk.API.PaymentProfile.GetAvailable.Request;

namespace PayNLSdk
{
    /// <summary>
    /// Obsolete, use PaymentProfileClient class
    /// </summary>
    [Obsolete("Use PaymentProfileClient class", true)]
    public class PaymentProfile
    {
    }

    /// <summary>
    /// Provides retrieval for payment options 
    /// </summary>
    public class PaymentProfileClient : IPaymentProfileClient
    {
        private readonly IClient _webClient;
        
        /// <summary>
        /// Create a new payment profile Sdk
        /// </summary>
        /// <param name="webClient"></param>
        public PaymentProfileClient(IClient webClient)
        {
            _webClient = webClient;
        }

       /// <inheritdoc />
        public PayNLSdk.API.PaymentProfile.Get.Response Get(int paymentProfileId)
        {
            var request = new PaymentProfileGet
            {
                PaymentProfileId = paymentProfileId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

       /// <inheritdoc />
        public PayNLSdk.API.PaymentProfile.GetAll.Response GetAll()
        {
            PaymentProfileGetAll request = new PaymentProfileGetAll();
            
            _webClient.PerformRequest(request);
            return request.Response;
        }

       /// <inheritdoc />
        public PayNLSdk.API.PaymentProfile.GetAvailable.Response GetAvailable(int categoryId, int? programId = null, int? paymentMethodId = null, bool? showNotAllowedOnRegistration = null)
        {
            var request = new PaymentProfileGetAvailable
            {
                CategoryId = categoryId,
                ProgramId = programId,
                PaymentMethodId = paymentMethodId,
                ShowNotAllowedOnRegistration = showNotAllowedOnRegistration
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

    }
}

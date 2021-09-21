﻿using PayNLSdk.Enums;
using PayNLSdk.Net;
using System;
using ServiceGetCategories = PayNLSdk.API.Service.GetCategories.Request;

namespace PayNLSdk
{
    /// <summary>
    /// Generic Service service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Service : IService
    {
        private readonly IClient _webClient;

        public Service(IClient webClient)
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
            ServiceGetCategories request = new ServiceGetCategories();
            request.PaymentOptionId = paymentOptionId;
            
            _webClient.PerformRequest(request);
            return request.Response;
        }

       
    }

}

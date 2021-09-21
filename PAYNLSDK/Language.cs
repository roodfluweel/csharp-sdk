﻿using PayNLSdk.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayNLSdk.API.Alliance;
using PayNLSdk.API.Alliance.GetMerchant;
using PayNLSdk.API.Language;

namespace PayNLSdk
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Language : ILanguage
    {
        private readonly IClient _webClient;

        /// <inheritdoc />
        public Language(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public GetMerchantResult GetAll()
        {
            var response = _webClient.PerformRequest(new GetAllRequest());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetMerchantResult>(response);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILanguage
    {
        GetMerchantResult GetAll();
    }
}
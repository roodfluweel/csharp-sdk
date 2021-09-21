using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.PaymentMethod.GetAll
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public PayNLSdk.Objects.PaymentMethod[] PaymentMethods { get; set; }
    }
}

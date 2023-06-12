using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.PaymentMethod.GetAll
{
    /// <summary>
    /// The response of a PaymentMethod GetAll call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public PayNLSdk.Objects.PaymentMethod[] PaymentMethods { get; set; }
    }
}

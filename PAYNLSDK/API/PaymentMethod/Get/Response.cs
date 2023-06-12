using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.PaymentMethod.Get
{
    /// <summary>
    /// The response of a PaymentMethod Get call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The result value
        /// </summary>
        public PayNLSdk.Objects.PaymentMethod PaymentMethod { get; set; }

    }
}

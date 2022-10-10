using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.PaymentProfile.Get
{
    /// <summary>
    /// The response of a PaymentProfile Get call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The result value
        /// </summary>
        public Objects.PaymentProfile PaymentProfile { get; set; }

    }
}

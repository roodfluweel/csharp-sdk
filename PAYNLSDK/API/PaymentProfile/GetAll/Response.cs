using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.PaymentProfile.GetAll
{
    /// <summary>
    /// The response of a PaymentProfile GetAll call
    /// </summary>
    public class Response : ResponseBase
    {
        public PayNLSdk.Objects.PaymentProfile[] PaymentProfiles { get; set; }
    }
}

using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.PaymentProfile.GetAll
{
    public class Response : ResponseBase
    {
        public PayNLSdk.Objects.PaymentProfile[] PaymentProfiles { get; set; }
    }
}

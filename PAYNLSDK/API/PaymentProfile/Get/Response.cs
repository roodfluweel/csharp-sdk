using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.PaymentProfile.Get
{
    public class Response : ResponseBase
    {
        public PayNLSdk.Objects.PaymentProfile PaymentProfile { get; set; }

    }
}

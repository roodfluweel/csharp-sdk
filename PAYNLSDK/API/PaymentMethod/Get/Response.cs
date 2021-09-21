using System;
using Newtonsoft.Json;

namespace PayNLSdk.API.PaymentMethod.Get
{
    public class Response : ResponseBase
    {
        public PayNLSdk.Objects.PaymentMethod PaymentMethod { get; set; }

    }
}

using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.PaymentProfile.Get
{
    /// <summary>
    /// The response of a PaymentProfile Get call
    /// </summary>
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentProfile PaymentProfile { get; set; }

    }
}

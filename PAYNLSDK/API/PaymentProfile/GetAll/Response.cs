using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.PaymentProfile.GetAll
{
    /// <summary>
    /// The response of a PaymentProfile GetAll call
    /// </summary>
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentProfile[] PaymentProfiles { get; set; }
    }
}

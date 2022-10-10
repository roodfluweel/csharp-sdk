﻿using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.PaymentMethod.Get
{
    /// <summary>
    /// The response of a PaymentMethod Get call
    /// </summary>
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentMethod PaymentMethod { get; set; }

    }
}

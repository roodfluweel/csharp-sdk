using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Service.GetCategories
{
    public class Response : ResponseBase
    {
        public PayNLSdk.Objects.ServiceCategory[] ServiceCategories { get; set; }
    }
}

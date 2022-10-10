using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Service.GetCategories
{
    /// <summary>
    /// The response of a Service GetCategories Call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// All the service categories
        /// </summary>
        public PAYNLSDK.Objects.ServiceCategory[] ServiceCategories { get; set; }
    }
}

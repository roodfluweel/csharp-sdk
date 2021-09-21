using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.Validate.BankAccountNumberInternational
{
    /// <summary>Class Response.
    /// Implements the <see cref="PayNLSdk.API.ResponseBase"/></summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PayNLSdk.API.Validate.BankAccountNumberInternational.Response" /> is succesful.
        /// </summary>
        /// <value><c>true</c> if succesful; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool Result { get; protected set; }
    }
}

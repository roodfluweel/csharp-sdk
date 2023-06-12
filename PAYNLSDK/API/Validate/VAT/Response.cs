using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.Validate.VAT
{

    /// <summary>
    /// Reponse of the <see cref="PayNLSdk.API.Validate.VAT.Request"/>.
    /// Implements the <see cref="PayNLSdk.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PayNLSdk.API.ResponseBase" />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response"/> is succesful.
        /// </summary>
        /// <value><c>true</c> if succesful; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

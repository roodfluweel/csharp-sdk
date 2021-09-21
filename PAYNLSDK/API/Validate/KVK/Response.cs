using Newtonsoft.Json;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.API.Validate.KVK
{
    /// <summary>
    /// The response object for <see cref="PayNLSdk.API.Validate.KVK.Request"/>
    /// Implements the <see cref="PayNLSdk.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PayNLSdk.API.ResponseBase" />
    /// <inheritdoc />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response"/> is result.
        /// </summary>
        /// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}

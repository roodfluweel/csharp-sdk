using System;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.API.Validate.GetServerIps
{
    /// <summary>
    /// Response object for the <see cref="PayNLSdk.API.Validate.GetServerIps.Request"/>.
    /// Implements the <see cref="PayNLSdk.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PayNLSdk.API.ResponseBase" />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets the ip addresses.
        /// </summary>
        /// <value>The ip addresses.</value>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public string[] IPAddresses { get; set; }
    }
}

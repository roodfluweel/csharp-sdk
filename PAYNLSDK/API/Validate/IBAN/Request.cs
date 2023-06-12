using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.API.Validate.IBAN
{
    /// <inheritdoc />
    /// <summary>
    /// Validate Iban Request
    /// Implements the <see cref="T:PayNLSdk.API.RequestBase" />
    /// </summary>
    /// <seealso cref="T:PayNLSdk.API.RequestBase" />
    public class Request : RequestBase
    {
        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>The iban.</value>
        [JsonProperty("iban")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public string IBAN { get; set; }

        /// <inheritdoc />
        public override bool RequiresApiToken => false;// base.RequiresApiToken;

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "IBAN";

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(IBAN, "iban");
            nvc.Add("iban", IBAN);

            return nvc;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}

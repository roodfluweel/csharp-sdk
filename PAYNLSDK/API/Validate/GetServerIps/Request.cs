using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.Validate.GetServerIps
{
    /// <inheritdoc />
    /// <summary>
    /// Request class for the SERVER IPs request.
    /// Implements the <see cref="T:PayNLSdk.API.RequestBase" />
    /// </summary>
    /// <seealso cref="T:PayNLSdk.API.RequestBase" />
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "getPayServerIps";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
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
            string[] ips = JsonConvert.DeserializeObject<string[]>(RawResponse);
            Response r = new Response
            {
                IPAddresses = ips
            };
            response = r;
        }
    }
}

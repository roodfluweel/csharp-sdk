using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.PaymentProfile.GetAll
{
    /// <summary>
    /// The request data for the PaymentProfile GetAll call
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "PaymentProfile";

        /// <inheritdoc />
        protected override string Method => "getAll";

        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        public Response Response => (Response)response;

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PayNLSdk.Objects.PaymentProfile[] pm = JsonConvert.DeserializeObject<PayNLSdk.Objects.PaymentProfile[]>(RawResponse);
            Response r = new Response
            {
                PaymentProfiles = pm
            };
            response = r;
        }
    }
}

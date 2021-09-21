using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.Service.GetCategories
{
    /// <summary>
    /// Returns a list of available service categories. 
    /// If a payment option is specified, only the categories linked to the payment option is returned 
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        ///  	The optional ID of the payment profile
        /// </summary>
        [JsonProperty("paymentOptionId")]
        public int? PaymentOptionId { get; set; }

        /// <inheritdoc />
        protected override int Version => 3;

        /// <inheritdoc />
        protected override string Controller => "Service";

        /// <inheritdoc />
        protected override string Method => "getCategories";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionId))
            {
                nvc.Add("paymentOptionId", PaymentOptionId.ToString());
            }
            return nvc;
        }

        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PayNLSdk.Objects.ServiceCategory[] pm = JsonConvert.DeserializeObject<PayNLSdk.Objects.ServiceCategory[]>(RawResponse);
            Response r = new Response
            {
                ServiceCategories = pm
            };
            response = r;
        }
    }
}

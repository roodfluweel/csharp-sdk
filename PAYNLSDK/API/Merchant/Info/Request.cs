using System.Collections.Specialized;
using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;

namespace PayNLSdk.API.Merchant.Info
{
    /// <summary>
    /// The request data for a <see cref="IMerchant.Get">Merchant Get</see> call
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// the merchant to request data for
        /// </summary>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        /// <inheritdoc />
        protected override int Version { get; } // ToDo: which version are we using?

        /// <inheritdoc />
        protected override string Controller => "Merchant";

        /// <inheritdoc />
        protected override string Method => "info";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();
            nvc.Add("merchantId", MerchantId);

            return nvc;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!response.Request.Result)
            {
                // toss
                throw new PayNlException(response.Request.Message);
            }
        }
    }
}

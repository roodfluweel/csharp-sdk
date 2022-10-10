using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Merchant.Get
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
            response = JsonConvert.DeserializeObject<API.Merchant.Get.Response>(RawResponse);
            if (!response.Request.Result)
            {
                // toss
                throw new PayNlException(response.Request.Message);
            }
        }
    }
}

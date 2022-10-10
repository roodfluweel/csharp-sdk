using System;
using Newtonsoft.Json;
using PayNLSdk.Utilities;
using System.Collections.Specialized;
using PayNLSdk.Exceptions;

namespace PayNLSdk.API.Transaction.GetLastTransactions
{
    /// <summary>
    /// The request data for the transaction GetLastTransactions call
    /// </summary>
    public class Request : RequestBase
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("paid")]
        public bool? Paid { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <inheritdoc />
        public override bool RequiresServiceId => true;

        /// <inheritdoc />
        protected override int Version => 5;

        /// <inheritdoc />
        protected override string Controller => "Transaction";

        /// <inheritdoc />
        protected override string Method => "getLastTransactions";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();
            if (!ParameterValidator.IsNull(MerchantId))
            {
                nvc.Add("merchantId", MerchantId);
            }
            if (!ParameterValidator.IsNull(Paid))
            {
                nvc.Add("paid", ((bool)Paid) ? "1" : "0");
            }
            if (!ParameterValidator.IsNull(Limit))
            {
                nvc.Add("limit", Limit.ToString());
            }
            return nvc;
        }

        /// <summary>
        /// the response of the api call
        /// </summary>
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

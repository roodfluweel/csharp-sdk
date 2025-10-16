using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PayNLSdk.API.Merchant.Clearing
{
    public class Request : RequestBase
    {
        protected override int Version => 4;

        protected override string Controller => "merchant";

        protected override string Method => "addClearing";

        /// <summary>
        ///  The amount to clear, will round on 2 decimals
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// The merchant to clear
        /// </summary>
        public string? MerchantId { get; set; }

        /// <summary>
        /// The content category Id.
        /// </summary>
        public string? ContentCategoryId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(Amount, "Amount");
            nvc.Add("amount", Math.Round(Amount * 100).ToString());
            nvc.Add("merchantId", MerchantId);
            nvc.Add("contentCategoryId", ContentCategoryId);

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        /// <inheritdoc />
        /// <exception cref="NotImplementedException"></exception>
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = Response.FromRawResponse(RawResponse);
            if (!Response.Request.Result)
            {
                throw new PayNlException(Response.Request.Code + " " + Response.Request.Message);
            }
        }
    }
}

using PAYNLSDK.API;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace PayNLSdk.API.Merchant.Clearing
{
    /// <summary>
    /// The request data for the Merchant Clearing call
    /// </summary>
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

        /// <inheritdoc />
        /// <exception cref="NotImplementedException"></exception>
        protected override void PrepareAndSetResponse()
        {
            throw new NotImplementedException();
        }
    }
}

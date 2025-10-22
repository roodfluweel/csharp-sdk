using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.AddClearing
{
    /// <summary>
    /// Request to add clearing for a merchant
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Merchant";
        /// <inheritdoc />
        protected override string Method => "addClearing";

        /// <summary>
        /// The amount in cents
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The merchant ID (optional)
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// The content category ID (optional)
        /// </summary>
        public string ContentCategoryId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (Amount <= 0)
            {
                throw new PayNlException("Amount is required and must be greater than 0");
            }

            var retval = new NameValueCollection 
            { 
                { "amount", Amount.ToString() }
            };

            if (!string.IsNullOrEmpty(MerchantId))
            {
                retval.Add("merchantId", MerchantId);
            }
            if (!string.IsNullOrEmpty(ContentCategoryId))
            {
                retval.Add("contentCategoryId", ContentCategoryId);
            }

            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}

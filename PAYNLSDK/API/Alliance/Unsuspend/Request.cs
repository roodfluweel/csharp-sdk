using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.Unsuspend
{
    /// <summary>
    /// Request to unsuspend a merchant
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 7;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "unsuspend";

        /// <summary>
        /// The merchant ID to unsuspend
        /// </summary>
        public string MerchantId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(MerchantId))
            {
                throw new PayNlException("MerchantId is required");
            }
            var retval = new NameValueCollection { { "merchantId", MerchantId } };
            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}

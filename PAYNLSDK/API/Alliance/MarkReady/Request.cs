using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.MarkReady
{
    /// <summary>
    /// Request to mark a merchant as ready
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Merchant";
        /// <inheritdoc />
        protected override string Method => "markReady";

        /// <summary>
        /// The merchant ID to mark as ready
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

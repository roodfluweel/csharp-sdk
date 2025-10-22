using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.SetPackage
{
    /// <summary>
    /// Request to set package for a merchant
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 7;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "setPackage";

        /// <summary>
        /// The merchant ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// The package name (e.g. "Alliance" or "AlliancePlus")
        /// </summary>
        public string Package { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(MerchantId))
            {
                throw new PayNlException("MerchantId is required");
            }
            if (ParameterValidator.IsEmpty(Package))
            {
                throw new PayNlException("Package is required");
            }
            var retval = new NameValueCollection 
            { 
                { "merchantId", MerchantId },
                { "package", Package }
            };
            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}

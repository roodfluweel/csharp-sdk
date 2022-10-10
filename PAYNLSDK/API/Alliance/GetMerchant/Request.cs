using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.GetMerchant
{
    /// <summary>
    /// The request data for a <see cref="IAlliance.GetMerchant"/> call
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "getMerchant";

        /// <summary>
        /// the merchant Id to request
        /// </summary>
        public string MerchantId { get; set; }
        
        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retVal = new NameValueCollection { { "merchantId", MerchantId } };
            return retVal;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            // response = JsonConvert.DeserializeObject<GetMerchantResult>(RawResponse);

        }
    }
}

using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.GetAvailablePaymentOptions
{
    /// <summary>
    /// Request to get available payment options for a service
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Service";
        /// <inheritdoc />
        protected override string Method => "getAvailablePaymentOptions";

        /// <summary>
        /// The service ID
        /// </summary>
        public string ServiceId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(ServiceId))
            {
                throw new PayNlException("ServiceId is required");
            }
            var retval = new NameValueCollection { { "serviceId", ServiceId } };
            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}

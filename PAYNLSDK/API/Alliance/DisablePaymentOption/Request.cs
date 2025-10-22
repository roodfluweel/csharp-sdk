using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.DisablePaymentOption
{
    /// <summary>
    /// Request to disable a payment option for a service
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Service";
        /// <inheritdoc />
        protected override string Method => "disablePaymentOption";

        /// <summary>
        /// The service ID
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// The payment profile ID (payment method ID)
        /// </summary>
        public string PaymentProfileId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(ServiceId))
            {
                throw new PayNlException("ServiceId is required");
            }
            if (ParameterValidator.IsEmpty(PaymentProfileId))
            {
                throw new PayNlException("PaymentProfileId is required");
            }

            var retval = new NameValueCollection 
            { 
                { "serviceId", ServiceId },
                { "paymentProfileId", PaymentProfileId }
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

using System.Collections.Generic;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.EnablePaymentOption
{
    /// <summary>
    /// Request to enable a payment option for a service
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Service";
        /// <inheritdoc />
        protected override string Method => "enablePaymentOption";

        /// <summary>
        /// The service ID
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// The payment profile ID (payment method ID)
        /// </summary>
        public string PaymentProfileId { get; set; }

        /// <summary>
        /// Optional: settings for the payment option
        /// </summary>
        public Dictionary<string, string> Settings { get; set; }

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

            if (Settings != null && Settings.Count > 0)
            {
                foreach (var setting in Settings)
                {
                    retval.Add($"settings[{setting.Key}]", setting.Value);
                }
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

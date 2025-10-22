using System.Collections.Specialized;

namespace PAYNLSDK.API.Alliance.GetCategories
{
    /// <summary>
    /// Request to get website categories
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Service";
        /// <inheritdoc />
        protected override string Method => "getCategories";

        /// <summary>
        /// Optional: filter by payment option ID
        /// </summary>
        public string PaymentOptionId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection();
            if (!string.IsNullOrEmpty(PaymentOptionId))
            {
                retval.Add("paymentOptionId", PaymentOptionId);
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

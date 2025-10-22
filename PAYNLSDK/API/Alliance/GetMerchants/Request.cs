using System.Collections.Specialized;

namespace PAYNLSDK.API.Alliance.GetMerchants
{
    /// <summary>
    /// Request to get a list of merchants
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 7;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "getMerchants";

        /// <summary>
        /// Filter by state: new, accepted or deleted
        /// </summary>
        public string State { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection();
            if (!string.IsNullOrEmpty(State))
            {
                retval.Add("state", State);
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

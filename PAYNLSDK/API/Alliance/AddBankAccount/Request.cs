using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.AddBankAccount
{
    /// <summary>
    /// Request to add a bank account for a merchant with iDEAL verification
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 7;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "addBankaccount";

        /// <summary>
        /// The merchant ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// The URL to redirect the user to after the iDEAL verification is completed
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Optional: the bank ID, if omitted, the user will be asked for the bank
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        /// Optional: the ID of the payment profile (standard iDEAL)
        /// </summary>
        public string PaymentOptionId { get; set; }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(MerchantId))
            {
                throw new PayNlException("MerchantId is required");
            }
            if (ParameterValidator.IsEmpty(ReturnUrl))
            {
                throw new PayNlException("ReturnUrl is required");
            }

            var retval = new NameValueCollection 
            { 
                { "merchantId", MerchantId },
                { "returnUrl", ReturnUrl }
            };

            if (!string.IsNullOrEmpty(BankId))
            {
                retval.Add("bankId", BankId);
            }
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

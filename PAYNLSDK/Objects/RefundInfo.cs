using System;
using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Refund Info Details
    /// </summary>
    public class RefundInfo
    {
        /// <summary>
        /// payment session ID
        /// </summary>
        [JsonProperty("paymentSessionId")]
        public long PaymentSessionId { get; set; }

        /// <summary>
        /// Refund amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        [JsonProperty("bankAccountHolder")]
        public string BankAccountHolder { get; set; }

        /// <summary>
        /// The bankaccount number of the customer.
        /// </summary>
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The BIC of the bank.
        /// </summary>
        [JsonProperty("bankAccountBic")]
        public string BankAccountBic { get; set; }

        /// <summary>
        /// status code
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// status description
        /// </summary>
        [JsonProperty("statusName")]
        public string StatusName { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        [JsonProperty("processDate")]
        public DateTime? ProcessDate { get; set; }

    }
}

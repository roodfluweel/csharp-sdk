using Newtonsoft.Json;

namespace PayNLSdk.API.BankTransfer.Add
{
    /// <summary>
    /// The response of a refund call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The ID of the refund transaction
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

using Newtonsoft.Json;

namespace PAYNLSDK.API.Banktransfer.Add
{
    /// <summary>
    /// The response of a bank transfer add call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The result value
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

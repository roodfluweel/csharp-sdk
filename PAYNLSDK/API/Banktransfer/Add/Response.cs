using Newtonsoft.Json;

namespace PAYNLSDK.API.Banktransfer.Add
{
    /// <summary>
    /// The response of a bank transfer add call
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

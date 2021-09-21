using Newtonsoft.Json;

namespace PayNLSdk.API.Banktransfer.Add
{
    public class Response : ResponseBase
    {
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}

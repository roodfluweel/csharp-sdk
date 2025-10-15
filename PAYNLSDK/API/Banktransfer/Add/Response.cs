using Newtonsoft.Json;

namespace PayNLSdk.Api.Banktransfer.Add;

public class Response : ResponseBase
{
    [JsonProperty("refundId")]
    public string RefundId { get; set; }
}

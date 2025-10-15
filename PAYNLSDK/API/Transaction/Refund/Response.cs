using Newtonsoft.Json;

namespace PayNLSdk.Api.Transaction.Refund;

public class Response : ResponseBase
{
    [JsonProperty("refundId")]
    public string RefundId { get; protected set; }
}

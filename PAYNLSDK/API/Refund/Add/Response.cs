using Newtonsoft.Json;

namespace PayNLSdk.Api.Refund.Add;

public class Response : ResponseBase
{
    /// <summary>
    /// ID of the refund starting with 'RF-' (optional, emptyfor creditcard transactions)
    /// </summary>
    [JsonProperty("refundId")]
    public string RefundId { get; set; }
}

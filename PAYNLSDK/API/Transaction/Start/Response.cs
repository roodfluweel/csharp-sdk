using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Transaction.Start;

public class Response : ResponseBase
{
    /// <summary>
    /// Information about the enduser
    /// </summary>
    [JsonPropertyName("endUser")]
    public Enduser EndUser { get; set; }
    /// <summary>
    /// The <see cref="TransactionData"/> for the started tranaction.  Containing the url and transactionId
    /// </summary>
    [JsonPropertyName("transaction")]
    public TransactionData Transaction { get; set; }

    public class Enduser
    {
        public string blacklist { get; set; }
    }

    public class TransactionData
    {
        [JsonPropertyName("transactionId")] public string TransactionId { get; set; }
        [JsonPropertyName("paymentURL")] public string PaymentUrl { get; set; }
        [JsonPropertyName("popupAllowed")] public string PopupAllowed { get; set; }
        [JsonPropertyName("paymentReference")] public string PaymentReference { get; set; }
    }

}

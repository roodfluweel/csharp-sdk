using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Transaction.Info;

/// <summary>
/// Storno Details
/// </summary>
public class StornoDetails
{
    /// <summary>
    /// ID of the refund
    /// </summary>
    [JsonPropertyName("stornoId")]
    public int? StornoId { get; protected set; }

    /// <summary>
    /// Refund amount
    /// </summary>
    [JsonPropertyName("stornoAmount")]
    public int? StornoAmount { get; protected set; }

    /// <summary>
    /// Number of the bankaccount the refund is deposited to
    /// </summary>
    [JsonPropertyName("bankAccount")]
    public string BankAccount { get; protected set; }

    /// <summary>
    /// IBAN of the bankaccount the refund is deposited to
    /// </summary>
    [JsonPropertyName("iban")]
    public string IBAN { get; protected set; }

    /// <summary>
    /// BIC of the bankaccount the refund is deposited to 
    /// </summary>
    [JsonPropertyName("bic")]
    public string bic { get; protected set; }

    /// <summary>
    /// City of the bankaccount owner 
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; protected set; }

    /// <summary>
    /// Date and time the payment is refunded 
    /// </summary>
    [JsonPropertyName("datetime")]
    public string Date { get; protected set; }

    /// <summary>
    /// Reason of the refund
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; protected set; }

    /// <summary>
    /// The email address the refund confirmation is sent to
    /// </summary>
    [JsonPropertyName("emailAdress")]
    public string EmailAddress { get; protected set; }

}

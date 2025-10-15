using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace PayNLSdk.Objects;

/// <summary>
/// Refund Info Details
/// </summary>
public class RefundInfo
{
    /// <summary>
    /// payment session ID
    /// </summary>
    [JsonPropertyName("paymentSessionId")]
    public long PaymentSessionId { get; set; }

    /// <summary>
    /// Refund amount
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    /// <summary>
    /// description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The name of the customer.
    /// </summary>
    [JsonPropertyName("bankAccountHolder")]
    public string BankAccountHolder { get; set; }

    /// <summary>
    /// The bankaccount number of the customer.
    /// </summary>
    [JsonPropertyName("bankAccountNumber")]
    public string BankAccountNumber { get; set; }

    /// <summary>
    /// The BIC of the bank.
    /// </summary>
    [JsonPropertyName("bankAccountBic")]
    public string BankAccountBic { get; set; }

    /// <summary>
    /// status code
    /// </summary>
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// status description
    /// </summary>
    [JsonPropertyName("statusName")]
    public string StatusName { get; set; }

    /// <summary>
    /// The currency of the amount, default is EUR.
    /// </summary>
    [JsonPropertyName("processDate")]
    public DateTime? ProcessDate { get; set; }

}

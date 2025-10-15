using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.Api.Transaction.Start;

/// <summary>
/// Transaction data
/// </summary>
public class TransactionData
{
    /// <summary>
    /// The currency of the transaction. If omitted, EUR is used.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Cost for VAT
    /// </summary>
    [JsonPropertyName("costsVat")]
    public int? CostsVat { get; set; }

    // No documentation is available to implement this
    //[JsonPropertyName("excludeCosts")]
    //public Array ExcludeCosts { get; set; }

    /// <summary>
    /// The URL of the exchange file that needs to be called
    /// </summary>
    [JsonPropertyName("orderExchangeUrl")]
    public string OrderExchangeUrl { get; set; }

    /// <summary>
    /// Description belonging to the order
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Expire date of the transaction
    /// </summary>
    [JsonPropertyName("expireDate")]
    public DateTime? ExpireDate { get; set; }

    /// <summary>
    /// The number belonging to the order
    /// </summary>
    [JsonPropertyName("orderNumber")]
    public string OrderNumber { get; set; }

    /// <summary>
    ///  	Unique id of the enduser
    /// </summary>
    [JsonPropertyName("enduserId")]
    public int? EnduserId { get; set; }

    /// <summary>
    /// Whether to sent a confimation email
    /// </summary>
    [JsonPropertyName("sendReminderEmail"), JsonConverter(typeof(BooleanConverter))]
    public bool SendReminderEmail { get; set; }

    /// <summary>
    /// The id of mailtemplate in case a confirmation mail needs to be sent
    /// </summary>
    [JsonPropertyName("reminderMailTemplateId")]
    public int? ReminderMailTemplateId { get; set; }


}

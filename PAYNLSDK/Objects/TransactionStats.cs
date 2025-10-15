using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;
using System;

namespace PayNLSdk.Objects;

/// <summary>
/// Payment Transaction Information
/// </summary>
public class TransactionStats
{
    /// <summary>
    /// Transaction identifier. 
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Name of the website used for the transaction
    /// </summary>
    [JsonPropertyName("websiteName")]
    public string WebsiteName { get; set; }

    /// <summary>
    /// Name of the service used for the transaction
    /// </summary>
    [JsonPropertyName("serviceName")]
    public string ServiceName { get; set; }

    /// <summary>
    /// Code of the service used for the transaction
    /// </summary>
    [JsonPropertyName("serviceCode")]
    public string ServiceCode { get; set; }

    /// <summary>
    /// Amount in cents of euro
    /// </summary>
    [JsonPropertyName("orderAmount")]
    public int OrderAmount { get; set; }

    /// <summary>
    /// Date and time of the transaction.
    /// </summary>
    [JsonPropertyName("created"), JsonConverter(typeof(YMDHISConverter))]
    public DateTime Created { get; set; }

    // TODO: this should be paymentstatus
    /// <summary>
    /// Internal status of the transaction
    /// </summary>
    [JsonPropertyName("internalStatus")]
    public int InternalStatus { get; set; }

    /// <summary>
    /// If Y mean that the payment was verified
    /// </summary>
    [JsonPropertyName("consumer3dsecure")]
    public string Consumer3dSecure { get; set; }

    /// <summary>
    /// Consumer account number
    /// </summary>
    [JsonPropertyName("consumerAccountNumber")]
    public string ConsumerAccountNumber { get; set; }

    /// <summary>
    /// ID of the Payment Profile used for this transaction
    /// </summary>
    [JsonPropertyName("profileId")]
    public int ProfileId { get; set; }

    /// <summary>
    /// Name of the Payment Profile used for this transaction
    /// </summary>
    [JsonPropertyName("profileName")]
    public string ProfileName { get; set; }

}

/// <summary>
/// List of Transaction Statusses
/// </summary>
public class TransactionStatsList
{
    /// <summary>
    /// Array containing the transactions stats
    /// </summary>
    [JsonPropertyName("transations")]
    public TransactionStats[] Transactions { get; set; }
}

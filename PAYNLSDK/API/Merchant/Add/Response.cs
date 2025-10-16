using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Utilities;

namespace PayNlSdk.Api.Merchant.Add;

/// <summary>
/// Reponse from the Merchant add command
/// </summary>
public class Response : ResponseBase
{
    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    /// <summary>
    /// The merchant name
    /// </summary>
    [JsonPropertyName("merchantName")] public string MerchantName { get; set; }
    /// <summary>
    /// Alliance or AlliancePlus
    /// </summary>
    [JsonPropertyName("packageName")] public string PackageName { get; set; }
    [JsonPropertyName("invoiceAllowed")] public bool GetInvoiceAllowed { get; set; }
    [JsonPropertyName("payoutInterval")] public string PayoutInterval { get; set; }
    /// <summary>
    /// The date the contract has been created.  
    /// </summary>
    [JsonPropertyName("createdDate")] public string CreatedDate { get; set; }
    /// <summary>
    /// The date when you can start using the services from PAY
    /// </summary>
    [JsonPropertyName("acceptedDate")] public string AcceptedDate { get; set; }
    [JsonPropertyName("deletedDate")] public string DeletedDate { get; set; }
    [JsonPropertyName("services")] public string Services { get; set; }

    /// <summary>
    /// Convert a raw response to an object
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public static Response FromRawResponse(string response)
    {
        return JsonSerialization.Deserialize<Response>(response);
    }
}
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetMerchants;

/// <summary>
/// Response for retrieving merchants that belong to the alliance account.
/// </summary>
public class GetMerchantsResult : ResponseBase
{
    /// <summary>
    /// Collection of merchants that match the requested filter.
    /// </summary>
    [JsonPropertyName("merchants")]
    public IReadOnlyList<Merchant>? Merchants { get; set; }

    /// <summary>
    /// Individual merchant entry.
    /// </summary>
    public class Merchant
    {
        [JsonPropertyName("merchantId")]
        public string? MerchantId { get; set; }

        [JsonPropertyName("merchantName")]
        public string? MerchantName { get; set; }

        [JsonPropertyName("packageName")]
        public string? PackageName { get; set; }

        [JsonPropertyName("contract")]
        public Contract? Contract { get; set; }

        [JsonPropertyName("services")]
        public IReadOnlyList<Service>? Services { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
    }

    /// <summary>
    /// Service information for the merchant.
    /// </summary>
    public class Service
    {
        [JsonPropertyName("serviceId")]
        public string? ServiceId { get; set; }

        [JsonPropertyName("serviceName")]
        public string? ServiceName { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
    }

    /// <summary>
    /// Contract information for the merchant.
    /// </summary>
    public class Contract
    {
        [JsonPropertyName("packageType")]
        public string? PackageType { get; set; }

        [JsonPropertyName("invoiceAllowed")]
        public string? InvoiceAllowed { get; set; }

        [JsonPropertyName("payoutInterval")]
        public string? PayoutInterval { get; set; }

        [JsonPropertyName("createdDate")]
        public string? CreatedDate { get; set; }

        [JsonPropertyName("acceptedDate")]
        public string? AcceptedDate { get; set; }

        [JsonPropertyName("deletedDate")]
        public string? DeletedDate { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
    }
}

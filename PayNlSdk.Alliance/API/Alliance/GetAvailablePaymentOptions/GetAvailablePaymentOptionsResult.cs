using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetAvailablePaymentOptions;

/// <summary>
/// Response containing the available payment options for a service.
/// </summary>
public class GetAvailablePaymentOptionsResult : ResponseBase
{
    /// <summary>
    /// Collection of payment options that can be enabled for the service.
    /// </summary>
    [JsonPropertyName("paymentOptions")]
    public IReadOnlyList<PaymentOption>? PaymentOptions { get; set; }

    /// <summary>
    /// Representation of a single payment option entry.
    /// </summary>
    public class PaymentOption
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("paymentOptionId")]
        public int? PaymentOptionId { get; set; }

        [JsonPropertyName("paymentProfileId")]
        public int? PaymentProfileId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("settings")]
        public Dictionary<string, JsonElement>? Settings { get; set; }
    }
}

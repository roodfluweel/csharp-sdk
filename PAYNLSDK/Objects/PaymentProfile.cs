using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;

namespace PayNLSdk.Objects;

/// <summary>
/// Payment Profile information
/// </summary>
public class PaymentProfile
{
    /// <summary>
    /// Payment Profile ID
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Payment Profile Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Payment Profile Parent ID
    /// </summary>
    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    /// <summary>
    /// Indicator if this Payment Profile is publicly available
    /// </summary>
    [JsonPropertyName("public"), JsonConverter(typeof(BooleanConverter))]
    public bool Public { get; set; }

    /// <summary>
    /// Payment Method ID this profile belongs to
    /// </summary>
    [JsonPropertyName("payment_method_id")]
    public int PaymentMethodId { get; set; }

    /// <summary>
    /// Country ID this payment profile belongs to.
    /// </summary>
    [JsonPropertyName("country_id")]
    public int CountryId { get; set; }

    /// <summary>
    /// ID of the Payment Tariff
    /// </summary>
    [JsonPropertyName("payment_tariff_id")]
    public int PaymentTariffId { get; set; }

    /// <summary>
    /// The nature of address, mostly used for PayPerCall and PayPerMinute to indicate wether this the payment was done with a mobile phone (1) or not (0). 
    /// </summary>
    [JsonPropertyName("noah_id")]
    public int NoahId { get; set; }

}

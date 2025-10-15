using Newtonsoft.Json;

namespace PayNLSdk.Objects;

/// <summary>
/// Payment Method information
/// </summary>
public class PaymentMethod
{
    /// <summary>
    /// Payment method ID
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Payment method name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Abbreviation for this payment method
    /// </summary>
    [JsonProperty("abbreviation")]
    public string Abbreviation { get; set; }

}

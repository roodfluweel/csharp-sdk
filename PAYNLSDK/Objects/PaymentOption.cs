using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Enums;
using System.Collections.Generic;

namespace PayNlSdk.Objects;

/// <summary>
/// Payment Option information base
/// </summary>
abstract public class PaymentOptionBase
{
    /// <summary>
    /// ID for this payment (sub)option
    /// </summary>
    [JsonPropertyName("id")]
    public int ID { get; set; }

    /// <summary>
    /// Name for this payment (sub)option
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Visible name for this payment (sub)option
    /// </summary>
    [JsonPropertyName("visibleName")]
    public string VisibleName { get; set; }

    /// <summary>
    /// Image for this payment (sub)option
    /// </summary>
    [JsonPropertyName("img")]
    public string Image { get; set; }

    /// <summary>
    /// Path for the (sub)option icon. The full icon URL is a concatenation of $basePath, $path and $img. 
    /// </summary>
    [JsonPropertyName("path")]
    public string IconPath { get; set; }

    /// <summary>
    /// Indicator whether or not the sub option is available
    /// </summary>
    [JsonPropertyName("state")]
    public Availability State { get; set; }

}

/// <summary>
/// Payment Suboption information
/// </summary>
public class PaymentSubOption : PaymentOptionBase
{
}

/// <summary>
/// Payment Suboptions Dictionary
/// </summary>
public class PaymentSubOptions : Dictionary<int, PaymentSubOption>
{
}

/// <summary>
/// Payment Option information
/// </summary>
public class PaymentOption : PaymentOptionBase
{
    /// <summary>
    /// ID of the Payment Method this option belongs to
    /// </summary>
    [JsonPropertyName("paymentMethodId")]
    public PaymentMethodId PaymentMethodId { get; set; }

    /// <summary>
    /// Dictionary of payment sub options
    /// </summary>
    [JsonPropertyName("paymentOptionSubList")]
    public PaymentSubOptions PaymentSubOptions { get; set; }
}

/// <summary>
/// Payment Options Dictionary
/// </summary>
public class PaymentOptions : Dictionary<int, PaymentOption>
{
}

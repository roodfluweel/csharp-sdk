using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Enums;

namespace PayNlSdk.Objects;

/// <summary>
/// Connection information
/// </summary>
public class Connection
{
    /// <summary>
    /// Trust indicator, from -10 to 10
    /// </summary>
    [JsonPropertyName("trust")]
    public int? Trust { get; protected set; }

    /// <summary>
    /// Country code fo the customer
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; protected set; }

    /// <summary>
    /// name of the city of the customer 
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; protected set; }

    /// <summary>
    /// Customer location, latitude
    /// </summary>
    [JsonPropertyName("locationLat")]
    public string LocationLat { get; protected set; }

    /// <summary>
    /// Customer location, longitude
    /// </summary>
    [JsonPropertyName("locationLon")]
    public string LocationLon { get; protected set; }

    /// <summary>
    /// Details of the cusomers browser. Specified on transaction start 
    /// </summary>
    [JsonPropertyName("browserData")]
    public string BrowserData { get; protected set; }

    /// <summary>
    /// IP address of the customer (during payment) 
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string IP { get; protected set; }

    /// <summary>
    /// Indicator whether or not the cusomer is blacklisted
    /// </summary>
    [JsonPropertyName("blacklist")]
    public Blacklist? Blacklist { get; protected set; }

    /// <summary>
    /// Hostaddress of the customer
    /// </summary>
    [JsonPropertyName("host")]
    public string Host { get; protected set; }

    /// <summary>
    /// Ip used in the order
    /// </summary>
    [JsonPropertyName("orderIpAddress")]
    public string OrderIP { get; protected set; }

    /// <summary>
    /// Used return URl in request
    /// </summary>
    [JsonPropertyName("orderReturnUrl")]
    public string OrderReturnUrl { get; protected set; }

    /// <summary>
    /// The corresponding merchant-code of the merchant
    /// </summary>
    [JsonPropertyName("merchantCode")]
    public string MerchantCode { get; protected set; }

    /// <summary>
    /// The corresponding name of the merchant
    /// </summary>
    [JsonPropertyName("merchantName")]
    public string MerchantName { get; protected set; }
}

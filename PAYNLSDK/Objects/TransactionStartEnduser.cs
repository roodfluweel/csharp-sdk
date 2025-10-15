using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Enums;

namespace PayNLSdk.Objects;

/// <summary>
/// 
/// </summary>
public class TransactionStartEnduser
{
    /// <summary>
    /// Indidicator whether or not the cusomer is blacklisted
    /// </summary>
    [JsonPropertyName("blacklist")]
    public Blacklist Blacklist { get; protected set; }
}

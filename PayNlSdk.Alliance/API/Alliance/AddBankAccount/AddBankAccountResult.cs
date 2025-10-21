using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.AddBankAccount;

/// <summary>
/// Response returned by the Alliance/addBankaccount endpoint.
/// </summary>
public class AddBankAccountResult : ResponseBase
{
    /// <summary>
    /// URL that the merchant should be redirected to in order to complete the flow.
    /// </summary>
    [JsonPropertyName("issuerUrl")]
    public string? IssuerUrl { get; set; }

    /// <summary>
    /// Indicates whether the request succeeded.
    /// </summary>
    [JsonIgnore]
    public bool Success => Request?.Result ?? false;
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Converters;
using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Api.Validate.BankAccountNumber;

/// <summary>
/// The reponse object for the bank account number validation
/// </summary>
public class Response : ResponseBase
{
    /// <summary>
    /// the result from the bank account number validation
    /// </summary>
    [JsonPropertyName("result"), JsonConverter(typeof(BooleanConverter))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public bool result { get; protected set; }
}

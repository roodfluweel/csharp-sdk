using Newtonsoft.Json;
using PayNLSdk.Converters;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.Api.Validate.BankAccountNumber;

/// <summary>
/// The reponse object for the bank account number validation
/// </summary>
public class Response : ResponseBase
{
    /// <summary>
    /// the result from the bank account number validation
    /// </summary>
    [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public bool result { get; protected set; }
}

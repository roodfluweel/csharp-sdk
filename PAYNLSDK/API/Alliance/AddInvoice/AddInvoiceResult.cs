using Newtonsoft.Json;

namespace PayNLSdk.Api.Alliance.AddInvoice;

/// <summary>
/// The result of the Alliance/GetMerchant call
/// Implements the <see cref="ResponseBase" />
/// </summary>
/// <seealso cref="ResponseBase" />
public class AddInvoiceResult : ResponseBase
{
    /// <summary>
    /// Gets or sets the reference id for the payment.
    /// </summary>
    /// <value>The reference identifier.</value>
    [JsonProperty("referenceId")]
    public string ReferenceId { get; set; }

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
        return $"AddInvoiceResult (referenceId={ReferenceId})";
    }
}
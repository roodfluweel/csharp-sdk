using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Api.Validate.GetServerIps;

/// <summary>
/// Response object for the <see cref="Request"/>.
/// Implements the <see cref="ResponseBase" />
/// </summary>
/// <seealso cref="ResponseBase" />
public class Response : ResponseBase
{
    /// <summary>
    /// Gets or sets the ip addresses.
    /// </summary>
    /// <value>The ip addresses.</value>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public string[] IPAddresses { get; set; }
}

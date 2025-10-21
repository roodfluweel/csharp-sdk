using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.MarkReady;

/// <summary>
/// Request payload to mark a merchant as ready.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "Merchant";

    /// <inheritdoc />
    protected override string Method => "markReady";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        if (string.IsNullOrWhiteSpace(MerchantId))
        {
            throw new ValidationException("MerchantId is required");
        }

        return new NameValueCollection
        {
            { "merchantId", MerchantId }
        };
    }

    /// <summary>
    /// Merchant identifier that should be marked ready.
    /// </summary>
    public string MerchantId { get; set; } = string.Empty;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

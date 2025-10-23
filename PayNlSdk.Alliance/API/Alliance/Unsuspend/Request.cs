using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.Unsuspend;

/// <summary>
/// Request payload to unsuspend a merchant.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 7;

    /// <inheritdoc />
    protected override string Controller => "Alliance";

    /// <inheritdoc />
    protected override string Method => "unsuspend";

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
    /// Merchant identifier that should be unsuspended.
    /// </summary>
    public string MerchantId { get; set; } = string.Empty;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

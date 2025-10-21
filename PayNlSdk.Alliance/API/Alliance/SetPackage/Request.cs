using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.SetPackage;

/// <summary>
/// Request payload for changing the package of a merchant.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 7;

    /// <inheritdoc />
    protected override string Controller => "Alliance";

    /// <inheritdoc />
    protected override string Method => "setPackage";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        if (string.IsNullOrWhiteSpace(MerchantId))
        {
            throw new ValidationException("MerchantId is required");
        }

        if (string.IsNullOrWhiteSpace(Package))
        {
            throw new ValidationException("Package is required");
        }

        return new NameValueCollection
        {
            { "merchantId", MerchantId },
            { "package", Package }
        };
    }

    /// <summary>
    /// Merchant identifier whose package should be changed.
    /// </summary>
    public string MerchantId { get; set; } = string.Empty;

    /// <summary>
    /// Desired package name.
    /// </summary>
    public string Package { get; set; } = string.Empty;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

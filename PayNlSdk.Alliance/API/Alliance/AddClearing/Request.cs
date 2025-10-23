using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.AddClearing;

/// <summary>
/// Request definition for the Merchant/addClearing endpoint.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "Merchant";

    /// <inheritdoc />
    protected override string Method => "addClearing";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (!AmountInCents.HasValue)
        {
            throw new ValidationException("AmountInCents is required");
        }

        parameters.Add("amount", AmountInCents.Value.ToString());

        if (!string.IsNullOrWhiteSpace(MerchantId))
        {
            parameters.Add("merchantId", MerchantId);
        }

        if (!string.IsNullOrWhiteSpace(ContentCategoryId))
        {
            parameters.Add("contentCategoryId", ContentCategoryId);
        }

        return parameters;
    }

    /// <summary>
    /// The amount to add to the clearing balance expressed in cents.
    /// </summary>
    public int? AmountInCents { get; set; }

    /// <summary>
    /// Optional merchant identifier.
    /// </summary>
    public string? MerchantId { get; set; }

    /// <summary>
    /// Optional content category identifier to attribute the clearing to.
    /// </summary>
    public string? ContentCategoryId { get; set; }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

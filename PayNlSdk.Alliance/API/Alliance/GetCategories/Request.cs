using System.Collections.Specialized;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetCategories;

/// <summary>
/// Request payload for retrieving service categories.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "service";

    /// <inheritdoc />
    protected override string Method => "getCategories";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (PaymentOptionId.HasValue)
        {
            parameters.Add("paymentOptionId", PaymentOptionId.Value.ToString());
        }

        return parameters;
    }

    /// <summary>
    /// Optional payment option identifier to filter the categories on.
    /// </summary>
    public int? PaymentOptionId { get; set; }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

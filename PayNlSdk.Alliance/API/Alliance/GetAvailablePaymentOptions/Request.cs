using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetAvailablePaymentOptions;

/// <summary>
/// Request for retrieving the list of available payment options for a service.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "service";

    /// <inheritdoc />
    protected override string Method => "getAvailablePaymentOptions";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        if (string.IsNullOrWhiteSpace(ServiceId))
        {
            throw new ValidationException("ServiceId is required");
        }

        var parameters = new NameValueCollection
        {
            { "serviceId", ServiceId }
        };

        return parameters;
    }

    /// <summary>
    /// Service identifier to query.
    /// </summary>
    public string ServiceId { get; set; } = string.Empty;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.DisablePaymentOption;

/// <summary>
/// Request payload for disabling a payment option for a service.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "service";

    /// <inheritdoc />
    protected override string Method => "disablePaymentOption";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (string.IsNullOrWhiteSpace(ServiceId))
        {
            throw new ValidationException("ServiceId is required");
        }

        if (!PaymentProfileId.HasValue)
        {
            throw new ValidationException("PaymentProfileId is required");
        }

        parameters.Add("serviceId", ServiceId);
        parameters.Add("paymentProfileId", PaymentProfileId.Value.ToString());

        return parameters;
    }

    /// <summary>
    /// Service identifier to act upon.
    /// </summary>
    public string ServiceId { get; set; } = string.Empty;

    /// <summary>
    /// Payment profile identifier that should be disabled.
    /// </summary>
    public int? PaymentProfileId { get; set; }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

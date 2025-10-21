using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.EnablePaymentOption;

/// <summary>
/// Request payload for enabling a payment option for a service.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;

    /// <inheritdoc />
    protected override string Controller => "service";

    /// <inheritdoc />
    protected override string Method => "enablePaymentOption";

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

        if (Settings.Count > 0)
        {
            foreach (var setting in Settings)
            {
                parameters.Add($"settings[{setting.Key}]", setting.Value);
            }
        }

        return parameters;
    }

    /// <summary>
    /// Service identifier to act upon.
    /// </summary>
    public string ServiceId { get; set; } = string.Empty;

    /// <summary>
    /// Payment profile identifier to enable.
    /// </summary>
    public int? PaymentProfileId { get; set; }

    /// <summary>
    /// Optional configuration settings for the payment profile.
    /// </summary>
    public IDictionary<string, string> Settings { get; } = new Dictionary<string, string>();

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

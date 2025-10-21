using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.GetMerchants;

/// <summary>
/// Request payload for retrieving a list of merchants.
/// </summary>
public class Request : RequestBase
{
    private static readonly HashSet<string> AllowedStates = new(StringComparer.OrdinalIgnoreCase)
    {
        "new",
        "accepted",
        "deleted"
    };

    /// <inheritdoc />
    protected override int Version => 7;

    /// <inheritdoc />
    protected override string Controller => "Alliance";

    /// <inheritdoc />
    protected override string Method => "getMerchants";

    /// <summary>
    /// Optional lifecycle state filter.
    /// </summary>
    public string? State { get; set; }

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (!string.IsNullOrWhiteSpace(State))
        {
            var normalized = State.ToLowerInvariant();
            if (!AllowedStates.Contains(normalized))
            {
                throw new ValidationException("State can only be 'new', 'accepted' or 'deleted'");
            }

            parameters.Add("state", normalized);
        }

        return parameters;
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

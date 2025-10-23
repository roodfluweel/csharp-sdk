using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.Statistics;

/// <summary>
/// Request payload for retrieving management statistics.
/// </summary>
public class Request : RequestBase
{
    private static readonly HashSet<string> ValidOperators = new(StringComparer.OrdinalIgnoreCase)
    {
        "eq",
        "neq",
        "gt",
        "lt",
        "like"
    };

    /// <inheritdoc />
    protected override int Version => 5;

    /// <inheritdoc />
    protected override string Controller => "Statistics";

    /// <inheritdoc />
    protected override string Method => "management";

    /// <summary>
    /// Start date for the statistics (inclusive).
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// End date for the statistics (inclusive).
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Group-by fields used by the statistics endpoint.
    /// </summary>
    public IList<string> GroupBy { get; } = new List<string> { "company_id", "payment_profile_id" };

    /// <summary>
    /// Filters that should be applied to the statistics query.
    /// </summary>
    public IList<Filter> Filters { get; } = new List<Filter>();

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        if (!StartDate.HasValue)
        {
            throw new ValidationException("StartDate is required");
        }

        if (!EndDate.HasValue)
        {
            throw new ValidationException("EndDate is required");
        }

        var parameters = new NameValueCollection();

        for (var i = 0; i < GroupBy.Count; i++)
        {
            parameters.Add($"groupBy[{i}]", GroupBy[i]);
        }

        parameters.Add("startDate", StartDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        parameters.Add("endDate", EndDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

        if (Filters.Count > 0)
        {
            for (var i = 0; i < Filters.Count; i++)
            {
                var filter = Filters[i];
                if (!ValidOperators.Contains(filter.Operator))
                {
                    throw new ValidationException($"Invalid operator '{filter.Operator}'. Valid operators are: {string.Join(", ", ValidOperators)}");
                }

                parameters.Add($"filterType[{i}]", filter.Key);
                parameters.Add($"filterOperator[{i}]", filter.Operator.ToLowerInvariant());
                parameters.Add($"filterValue[{i}]", filter.Value);
            }
        }

        return parameters;
    }

    /// <summary>
    /// Adds a filter clause to the request.
    /// </summary>
    public void AddFilter(string key, string value, string @operator = "eq")
    {
        Filters.Add(new Filter(key, value, @operator));
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

/// <summary>
/// Definition of a statistics filter clause.
/// </summary>
public class Filter
{
    public Filter(string key, string value, string @operator = "eq")
    {
        Key = key;
        Value = value;
        Operator = @operator;
    }

    public string Key { get; }

    public string Value { get; }

    public string Operator { get; }
}

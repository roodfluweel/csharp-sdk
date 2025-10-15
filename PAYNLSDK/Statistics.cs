using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Api.Statistics.GetManagement;
using PayNLSdk.Net;
using System.Collections.Generic;
using PayNLSdk.Utilities;

namespace PayNLSdk;

/// <summary>
/// This is a part of the alliance SDK
/// </summary>
/// <inheritdoc />
public class Statistics : IStatistics
{
    private readonly IClient _webClient;

    /// <inheritdoc />
    public Statistics(IClient webClient)
    {
        _webClient = webClient;
    }

    /// <summary>
    /// Get management statistics from the RestApi
    /// </summary>
    /// <param name="request"></param>
    /// <param name="groupByFieldName">The fieldname on which the grouping has to take place</param>
    /// <returns></returns>
    public GetStatsResult GetStats(Request request, string groupByFieldName = "")
    {
        if (string.IsNullOrWhiteSpace(groupByFieldName)) { groupByFieldName = "company_id"; }
        request.GroupByFieldNames.Clear();
        request.GroupByFieldNames.Add(groupByFieldName);

        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetStatsResult>(response);
    }

    /// <summary>
    /// Get management statistics from the Api using two group by fields
    /// </summary>
    /// <param name="request"></param>
    /// <param name="groupByFieldName"></param>
    /// <param name="groupByFieldName2"></param>
    /// <returns></returns>
    public GetStatsMultiLevel GetMultiLevelStats(Request request, string groupByFieldName, string groupByFieldName2 = "day")
    {
        if (string.IsNullOrWhiteSpace(groupByFieldName)) { groupByFieldName = "company_id"; }
        if (string.IsNullOrWhiteSpace(groupByFieldName2)) { groupByFieldName2 = "day"; }

        request.GroupByFieldNames.Clear();
        request.GroupByFieldNames.Add(groupByFieldName);
        request.GroupByFieldNames.Add(groupByFieldName2);

        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetStatsMultiLevel>(response);
    }
}

/// <summary>
/// Get alliance statistics
/// </summary>
public interface IStatistics
{
    /// <summary>
    /// Get management statistics from the RestApi
    /// </summary>
    /// <param name="request"></param>
    /// <param name="groupByFieldName">The fieldname on which the grouping has to take place</param>
    /// <returns></returns>
    GetStatsResult GetStats(Request request, string groupByFieldName = "");

    /// <summary>
    /// Get management statistics from the Api using two group by fields
    /// </summary>
    /// <param name="request"></param>
    /// <param name="groupByFieldName"></param>
    /// <param name="groupByFieldName2"></param>
    /// <returns></returns>
    GetStatsMultiLevel GetMultiLevelStats(Request request, string groupByFieldName, string groupByFieldName2 = "day");
}

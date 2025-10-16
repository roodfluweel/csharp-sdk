using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Statistics.GetManagement;

/// <summary>
/// If 2 groupBy parameters are added to the request,
/// we have a Top-level and a sublevel of data
/// </summary>
public class GetStatsMultiLevel : GetStatsResultBase
{
    [JsonPropertyName("arrStatsData")]
    public TopLevelStatsData[] TopLevelGroup { get; set; }
}

    public class TopLevelStatsData
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public GetStatsResultBase.StatsLine[] Data { get; set; }
}

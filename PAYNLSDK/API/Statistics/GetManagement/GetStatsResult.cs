using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Api.Statistics.GetManagement;

/// <summary>
/// The result of the Statistics/Management call
/// With a maximum of one group
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GetStatsResult : GetStatsResultBase
{
    [JsonPropertyName("arrStatsData")]
    public StatsData[] ArrStatsData { get; set; }
}

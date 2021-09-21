using Newtonsoft.Json;

namespace PayNLSdk.API.Statistics.GetManagement
{
    /// <summary>
    /// If 2 groupBy parameters are added to the request,
    /// we have a Top-level and a sublevel of data
    /// </summary>
    public class GetStatsMultiLevel : GetStatsResultBase
    {
        [JsonProperty("arrStatsData")]
        public TopLevelStatsData[] TopLevelGroup { get; set; }
    }

    public class TopLevelStatsData
    {
        public string Id { get; set; }
        /// <summary>
        /// The name of the Data
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// An array with all the values
        /// </summary>
        public GetStatsResultBase.StatsData[] Data { get; set; }
    }

   


}

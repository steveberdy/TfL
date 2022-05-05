using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-34
    /// </summary>
    public class TfLSchedule
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("knownJourneys")] public TfLJourney[] KnownJourneys { get; set; }
        [JsonProperty("firstJourney")] public TfLJourney FirstJourney { get; set; }
        [JsonProperty("lastJourney")] public TfLJourney LastJourney { get; set; }
        [JsonProperty("periods")] public TfLPeriod[] Periods { get; set; }
    }
}
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-23
    /// </summary>
    public class TfLRoutesAndStops
    {
        [JsonProperty("lineId")]
        public string LineId { get; set; }
        [JsonProperty("lineName")]
        public string LineName { get; set; }
        [JsonProperty("direction")]
        public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("isOutboundOnly")]
        public bool IsOutboundOnly { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("lineStrings")]
        public string[] LineStrings { get; set; }
        [JsonProperty("stations")]
        public TfLStation[] Stations { get; set; }
        [JsonProperty("stopPointSequences")]
        public TfLStopPointSequence[] StopPointSequences { get; set; }
        [JsonProperty("orderedLineRoutes")]
        public TfLOrderedLineRoute[] OrderedLineRoutes { get; set; }
    }
}
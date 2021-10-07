using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-7
    /// </summary>
    public class TfLLineGroup
    {
        [JsonProperty("naptanIdReference")]
        public string NaptanIdReference { get; set; }
        [JsonProperty("stationAtcoCode")]
        public string StationAtcoCode { get; set; }
        [JsonProperty("lineIdentifier")]
        public string[] LineIdentifier { get; set; }
    }
}
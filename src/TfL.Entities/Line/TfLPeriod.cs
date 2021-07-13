using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-33
    /// </summary>
    public class TfLPeriod
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("fromTime")]
        public TfLTime FromTime { get; set; }
        [JsonProperty("toTime")]
        public TfLTime ToTime { get; set; }
        [JsonProperty("frequency")]
        public TfLFrequency Frequency { get; set; }
    }
}
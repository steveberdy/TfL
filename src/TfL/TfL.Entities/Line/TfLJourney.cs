using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-30
    /// </summary>
    public class TfLJourney
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }
        [JsonProperty("minute")]
        public string Minute { get; set; }
        [JsonProperty("intervalId")]
        public int IntervalId { get; set; }
    }
}
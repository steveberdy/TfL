using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-29
    /// </summary>
    public class TfLStationInterval
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("intervals")]
        public TfLInterval[] Intervals { get; set; }
    }
}
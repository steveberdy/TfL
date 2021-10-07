using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-31
    /// </summary>
    public class TfLTime
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }
        [JsonProperty("minute")]
        public string Minute { get; set; }
    }
}
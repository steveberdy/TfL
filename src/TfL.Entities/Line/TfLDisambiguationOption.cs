using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-37
    /// </summary>
    public class TfLDisambiguationOption
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
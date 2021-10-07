using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-12
    /// </summary>
    public class TfLRouteSectionNaptanEntry
    {
        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }
        [JsonProperty("stopPoint")]
        public TfLStopPoint StopPoint { get; set; }
    }
}
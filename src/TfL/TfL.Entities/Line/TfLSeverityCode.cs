using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-2
    /// </summary>
    public class TfLSeverityCode
    {
        [JsonProperty("modeName")] public string ModeName { get; set; }
        [JsonProperty("severityLevel")] public int SeverityLevel { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
    }
}
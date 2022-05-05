using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-8
    /// </summary>
    public class TfLLineModeGroup
    {
        [JsonProperty("modeName")] public string ModeName { get; set; }
        [JsonProperty("lineIdentifier")] public string[] LineIdentifier { get; set; }
    }
}
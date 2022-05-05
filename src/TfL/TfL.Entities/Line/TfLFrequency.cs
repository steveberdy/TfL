using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-32
    /// </summary>
    public class TfLFrequency
    {
        [JsonProperty("lowestFrequency")] public double LowestFrequency { get; set; }
        [JsonProperty("highestFrequency")] public double HighestFrequency { get; set; }
    }
}
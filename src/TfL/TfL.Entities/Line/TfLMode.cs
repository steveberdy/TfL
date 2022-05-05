using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl
    /// </summary>
    public class TfLMode
    {
        [JsonProperty("isTflService")] public bool IsTflService { get; set; }
        [JsonProperty("isFarePaying")] public bool IsFarePaying { get; set; }
        [JsonProperty("isScheduledService")] public bool IsScheduledService { get; set; }
        [JsonProperty("modeName")] public string ModeName { get; set; }
    }
}
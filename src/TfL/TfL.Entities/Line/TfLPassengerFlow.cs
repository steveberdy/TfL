using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-3
    /// </summary>
    public class TfLPassengerFlow
    {
        [JsonProperty("timeSlice")] public string TimeSlice { get; set; }
        [JsonProperty("value")] public int Value { get; set; }
    }
}
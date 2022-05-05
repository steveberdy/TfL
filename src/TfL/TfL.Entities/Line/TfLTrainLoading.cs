using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-4
    /// </summary>
    public class TfLTrainLoading
    {
        [JsonProperty("line")] public string Line { get; set; }
        [JsonProperty("lineDirection")] public string LineDirection { get; set; }
        [JsonProperty("platformDirection")] public string PlatformDirection { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("naptanTo")] public string NaptanTo { get; set; }
        [JsonProperty("timeSlice")] public string TimeSlice { get; set; }
        [JsonProperty("value")] public int Value { get; set; }
    }
}
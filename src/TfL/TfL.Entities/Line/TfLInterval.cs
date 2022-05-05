using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-28
    /// </summary>
    public class TfLInterval
    {
        [JsonProperty("stopId")] public string StopId { get; set; }
        [JsonProperty("timeToArrival")] public double TimeToArrival { get; set; }
    }
}
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-36
    /// </summary>
    public class TfLTimetable
    {
        [JsonProperty("departureStopId")]
        public string DepartureStopId { get; set; }
        [JsonProperty("routes")]
        public TfLRouteTimetable[] Routes { get; set; }
    }
}
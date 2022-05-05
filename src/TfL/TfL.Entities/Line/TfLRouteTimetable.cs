using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-35
    /// </summary>
    public class TfLRouteTimetable
    {
        [JsonProperty("stationIntervals")] public TfLStationInterval[] StationIntervals { get; set; }
        [JsonProperty("schedules")] public TfLSchedule[] Schedules { get; set; }
    }
}
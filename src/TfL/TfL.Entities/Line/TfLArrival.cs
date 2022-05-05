using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Arrival prediction details
    /// Tfl-41
    /// </summary>
    public class TfLArrival
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("operationType")] public int OperationType { get; set; }
        [JsonProperty("vehicleId")] public string VehicleId { get; set; }
        [JsonProperty("naptanId")] public string NaptanId { get; set; }
        [JsonProperty("stationName")] public string StationName { get; set; }
        [JsonProperty("lineId")] public string LineId { get; set; }
        [JsonProperty("lineName")] public string LineName { get; set; }
        [JsonProperty("platformName")] public string PlatformName { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("bearing")] public string Bearing { get; set; }
        [JsonProperty("destinationNaptanId")] public string DestinationNaptanId { get; set; }
        [JsonProperty("destinationName")] public string DestinationName { get; set; }
        [JsonProperty("timestamp")] public DateTime Timestamp { get; set; }
        [JsonProperty("timeToStation")] public int TimeToStation { get; set; } // in seconds
        [JsonProperty("currentLocation")] public string CurrentLocation { get; set; }
        [JsonProperty("towards")] public string Towards { get; set; }
        [JsonProperty("expectedArrival")] public DateTime ExpectedArrival { get; set; }
        [JsonProperty("timeToLive")] public DateTime TimeToLive { get; set; }
        [JsonProperty("modeName")] public string ModeName { get; set; }
        [JsonProperty("timing")] public TfLTiming Timing { get; set; }
    }
}
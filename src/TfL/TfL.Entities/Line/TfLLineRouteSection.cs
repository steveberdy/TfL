using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-24
    /// </summary>
    public class TfLLineRouteSection
    {
        [JsonProperty("routeId")] public int RouteId { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("destinationo")] public string Destination { get; set; }
        [JsonProperty("fromStation")] public string FromStation { get; set; }
        [JsonProperty("toStation")] public string ToStation { get; set; }
        [JsonProperty("serviceType")] public TfLServiceTypeEnum ServiceType { get; set; }
        [JsonProperty("vehicleDestinationText")] public string VehicleDestinationText { get; set; }
    }
}
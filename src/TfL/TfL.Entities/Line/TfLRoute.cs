using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-13
    /// </summary>
    public class TfLRoute
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("lineId")] public string LineId { get; set; }
        [JsonProperty("routeCode")] public string RouteCode { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("lineString")] public string LineString { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("originationName")] public string OriginationName { get; set; }
        [JsonProperty("destinationName")] public string DestinationName { get; set; }
        [JsonProperty("validTo")] public DateTime ValidTo { get; set; }
        [JsonProperty("validFrom")] public DateTime ValidFrom { get; set; }
        [JsonProperty("routeSectionNaptanEntrySequence")] public TfLRouteSectionNaptanEntry[] RouteSectionNaptanEntrySequence { get; set; }
    }
}
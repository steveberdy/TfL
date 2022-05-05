using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-20
    /// </summary>
    public class TfLStation
    {
        [JsonProperty("routeId")] public int RouteId { get; set; }
        [JsonProperty("parentId")] public string ParentId { get; set; }
        [JsonProperty("stationId")] public string StationId { get; set; }
        [JsonProperty("icsId")] public string IcsId { get; set; }
        [JsonProperty("topMostParentId")] public string TopMostParentId { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("towards")] public string Towards { get; set; }
        [JsonProperty("modes")] public string[] Modes { get; set; }
        [JsonProperty("stopType")] public string StopType { get; set; }
        [JsonProperty("stopLetter")] public string StopLetter { get; set; }
        [JsonProperty("zone")] public string Zone { get; set; }
        [JsonProperty("accessibilitySummary")] public string AccessibilitySummary { get; set; }
        [JsonProperty("hasDisruption")] public bool HasDiruption { get; set; }
        [JsonProperty("lines")] public TfLLine[] Lines { get; set; }
        [JsonProperty("status")] public bool Status { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("lat")] public double Latitude { get; set; }
        [JsonProperty("lon")] public double Longitude { get; set; }
    }
}
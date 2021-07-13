using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-26
    /// </summary>
    public class TfLSearchMatch
    {
        [JsonProperty("lineId")]
        public string LineId { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("lineName")]
        public string LineName { get; set; }
        [JsonProperty("lineRouteSection")]
        public TfLLineRouteSection[] LineRouteSection { get; set; }
        [JsonProperty("matchedRouteSections")]
        public TfLRouteSectionId[] MatchedRouteSections { get; set; }
        [JsonProperty("matchedStops")]
        public TfLStation[] MatchedStops { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
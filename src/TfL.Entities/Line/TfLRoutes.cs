using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-19
    /// </summary>
    public class TfLRoutes
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("modeName")]
        public string ModeName { get; set; }
        [JsonProperty("disruptions")]
        public TfLDisruption[] Disruptions { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
        [JsonProperty("lineStatuses")]
        public TfLLineStatus[] LineStatuses { get; set; }
        [JsonProperty("routeSections")]
        public TfLRouteSection[] RouteSections { get; set; }
        [JsonProperty("serviceTypes")]
        public TfLServiceType[] ServiceTypes { get; set; }
        [JsonProperty("crowding")]
        public TfLCrowding Crowding { get; set; }
    }
}
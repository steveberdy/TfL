using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Represents a disruption to a route within the transport network.
    /// Tfl-14
    /// </summary>
    public class TfLDisruption
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("categoryDescription")]
        public string CategoryDescription { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("affectedRoutes")]
        public TfLRoute[] AffectedRoutes { get; set; }
        [JsonProperty("affectedStops")]
        public TfLStopPoint[] AffectedStops { get; set; }
        [JsonProperty("closureText")]
        public string ClosureText { get; set; }
    }
}
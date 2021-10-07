using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Description of a Route used in Route search results.
    /// Tfl-17
    /// </summary>
    public class TfLRouteSection
    {
        [JsonProperty("routeCode")]
        public string RouteCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("direction")]
        public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("originationName")]
        public string OriginationName { get; set; }
        [JsonProperty("destinationName")]
        public string DestinationName { get; set; }
        [JsonProperty("originator")]
        public string Originator { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonProperty("serviceType")]
        public TfLServiceTypeEnum ServiceType { get; set; }
        [JsonProperty("validTo")]
        public DateTime ValidTo { get; set; }
        [JsonProperty("validFrom")]
        public DateTime ValidFrom { get; set; }
    }
}
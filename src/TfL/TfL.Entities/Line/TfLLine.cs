using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-6
    /// </summary>
    public class TfLLine
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("crowding")]
        public TfLCrowding Crowding { get; set; }
        [JsonProperty("routeType")]
        public string RouteType { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using TfL.Converters;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-10
    /// </summary>
    public class TfLStopPointChild
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("commonName")]
        public string CommonName { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("placeType")]
        public string PlaceType { get; set; }
        [JsonProperty("additionalProperties"), JsonConverter(typeof(TfLStopPointPropertyConverter))]
        public Dictionary<string, string[]> StationServices { get; set; }
        [JsonProperty("children")]
        public TfLStopPointChild[] Children { get; set; }
        [JsonProperty("childrenurls")]
        public string[] ChildrenUrls { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
using Newtonsoft.Json;
using TfL.Converters;

namespace TfL.Entities
{
    public class TfLBikePointPlace
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("commonName")] public string CommonName { get; set; }
        [JsonProperty("distance")] public double Distance { get; set; }
        [JsonProperty("placeType")] public string PlaceType { get; set; }
        [JsonProperty("additionalProperties"), JsonConverter(typeof(TfLBikePointPropertyConverter))] public TfLBikePoint BikePoint { get; set; }
        [JsonProperty("children")] public TfLBikePointPlace[] Children { get; set; }
        [JsonProperty("childrenUrls")] public string[] ChildrenUrls { get; set; }
        [JsonProperty("lat")] public double Latitude { get; set; }
        [JsonProperty("lon")] public double Longitude { get; set; }
    }
}
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-22
    /// </summary>
    public class TfLOrderedLineRoute
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("naptanIds")] public string[] NaptanIds { get; set; }
        [JsonProperty("serviceType")] public TfLServiceTypeEnum ServiceType { get; set; }
    }
}
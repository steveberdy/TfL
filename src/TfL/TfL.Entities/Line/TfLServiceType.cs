using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-18
    /// </summary>
    public class TfLServiceType
    {
        [JsonProperty("name")] public TfLServiceTypeEnum Name { get; set; }
        [JsonProperty("uri")] public string Uri { get; set; }
    }
}
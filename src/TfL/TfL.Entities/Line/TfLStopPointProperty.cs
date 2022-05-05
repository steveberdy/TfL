using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Generic Addditional Property
    /// Tfl-9
    /// </summary>
    public class TfLStopPointProperty
    {
        [JsonProperty("category")] public string Category { get; set; }
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("sourceSystemKey")] public string SourceSystemKey { get; set; }
        [JsonProperty("value")] public string Value { get; set; }
        [JsonProperty("modified")] public DateTime Modified { get; set; }
    }
}
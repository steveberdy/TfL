using System;
using Newtonsoft.Json;
using TfL.Converters;

namespace TfL.Entities
{
    public class TfLBikePointProperty
    {
        [JsonProperty("category")] public string Category { get; set; }
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("sourceSystemKey")] public string SourceSystemKey { get; set; }
        [JsonProperty("value")] public string Value { get; set; }
        [JsonProperty("modified")] public DateTime Modified { get; set; }
    }
}
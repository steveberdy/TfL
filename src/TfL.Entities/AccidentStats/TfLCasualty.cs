using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLCasualty
    {
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("severity")]
        public string Severity { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("ageBand")]
        public string AgeBand { get; set; }
    }
}
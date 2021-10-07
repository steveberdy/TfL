using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLVehicle
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLAccidentStats
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("severity")]
        public string Severity { get; set; }
        [JsonProperty("borough")]
        public string Borough { get; set; }
        [JsonProperty("casualties")]
        public TfLCasualty[] Casualties { get; set; }
        [JsonProperty("vehicles")]
        public TfLVehicle[] Vehicles { get; set; }
    }
}
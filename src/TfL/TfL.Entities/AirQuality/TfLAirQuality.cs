using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLAirQuality
    {
        [JsonProperty("updatePeriod")]
        public string UpdatePeriod { get; set; }
        [JsonProperty("updateFrequency")]
        public string UpdateFrequency { get; set; }
        [JsonProperty("forecastUrl")]
        public string ForecastUrl { get; set; }
        [JsonProperty("disclaimerText")]
        public string DisclaimerText { get; set; }
        [JsonProperty("currentForecast")]
        public TfLAirForecast[] CurrentForecast { get; set; }
    }
}
using Newtonsoft.Json;
using TfL.Converters;

namespace TfL.Entities
{
    public class TfLAirForecast
    {
        [JsonProperty("forecastType")] public string ForecastType { get; set; }
        [JsonProperty("forecastID")] public string ForecastId { get; set; }
        [JsonProperty("forecastBand")] public string ForecastBand { get; set; }
        [JsonProperty("forecastSummary")] public string ForecastSummary { get; set; }
        [JsonProperty("nO2Band")] public string NO2Band { get; set; }
        [JsonProperty("o3Band")] public string O3Band { get; set; }
        [JsonProperty("pM10Band")] public string PM10Band { get; set; }
        [JsonProperty("pM25Band")] public string PM25Band { get; set; }
        [JsonProperty("sO2Band")] public string SO2Band { get; set; }
        [JsonProperty("forecastText"), JsonConverter(typeof(TfLForecastTextConverter))] public string ForecastText { get; set; }
    }
}
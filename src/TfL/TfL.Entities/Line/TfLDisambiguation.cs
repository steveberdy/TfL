using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-38
    /// </summary>
    public class TfLDisambiguation
    {
        [JsonProperty("disambiguationOptions")]
        public TfLDisambiguationOption[] DisambiguationOptions { get; set; }
    }
}
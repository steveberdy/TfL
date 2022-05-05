using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-27
    /// </summary>
    public class TfLSearchResult
    {
        [JsonProperty("input")] public string Input { get; set; }
        [JsonProperty("SearchMatches")] public TfLSearchMatch[] SearchMatches { get; set; }
    }
}
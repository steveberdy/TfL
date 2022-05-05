using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-25
    /// </summary>
    public class TfLRouteSectionId
    {
        [JsonProperty("id")] public int Id { get; set; }
    }
}
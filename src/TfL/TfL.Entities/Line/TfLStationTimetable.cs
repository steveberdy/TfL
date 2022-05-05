using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-39
    /// </summary>
    public class TfLStationTimetable
    {
        [JsonProperty("lineId")] public string LineId { get; set; }
        [JsonProperty("lineName")] public string LineName { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("pdfUrl")] public string PdfUrl { get; set; }
        [JsonProperty("stations")] public TfLStation[] Stations { get; set; }
        [JsonProperty("stops")] public TfLStation[] Stops { get; set; }
        [JsonProperty("timetable")] public TfLTimetable Timetable { get; set; }
        [JsonProperty("disambiguation")] public TfLDisambiguation Disambiguation { get; set; }
        [JsonProperty("statusErrorMessage")] public string StatusErrorMessage { get; set; }
    }
}
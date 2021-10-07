using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-16
    /// </summary>
    public class TfLLineStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("lineId")]
        public string LineId { get; set; }
        [JsonProperty("statusSeverity")]
        public int StatusSeverity { get; set; }
        [JsonProperty("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
        [JsonProperty("validityPeriods")]
        public TfLValidityPeriod[] ValidityPeriods { get; set; }
        [JsonProperty("disruption")]
        public TfLDisruption Disruption { get; set; }
    }
}
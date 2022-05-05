using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Represents a period for which a planned works is valid.
    /// Tfl-15
    /// </summary>
    public class TfLValidityPeriod
    {
        [JsonProperty("fromDate")] public DateTime FromDate { get; set; }
        [JsonProperty("toDate")] public DateTime ToDate { get; set; }
        [JsonProperty("isNow")] public bool IsNow { get; set; }
    }
}
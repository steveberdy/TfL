using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-40
    /// </summary>
    public class TfLTiming
    {
        [JsonProperty("countdownServerAdjustment")] public string CountdownServerAdjustment { get; set; }
        [JsonProperty("source")] public DateTime Source { get; set; }
        [JsonProperty("insert")] public DateTime Insert { get; set; }
        [JsonProperty("read")] public DateTime Read { get; set; }
        [JsonProperty("sent")] public DateTime Sent { get; set; }
        [JsonProperty("received")] public DateTime Received { get; set; }
    }
}
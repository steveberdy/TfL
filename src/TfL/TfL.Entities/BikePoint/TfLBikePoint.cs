using System;
using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLBikePoint
    {
        [JsonProperty("terminalName")]
        public string TerminalName { get; set; }
        [JsonProperty("installed")]
        public bool Installed { get; set; }
        [JsonProperty("locked")]
        public bool? Locked { get; set; }
        [JsonProperty("installDate")]
        public DateTime InstallDate { get; set; }
        [JsonProperty("removalDate")]
        public DateTime RemovalDate { get; set; }
        [JsonProperty("temporary")]
        public bool? Temporary { get; set; }
        [JsonProperty("bikes")]
        public int Bikes { get; set; }
        [JsonProperty("emptyDocks")]
        public int EmptyDocks { get; set; }
        [JsonProperty("totalDocks")]
        public int TotalDocks { get; set; }
        [JsonProperty("brokenDocks")]
        public int BrokenDocks => TotalDocks - Bikes - EmptyDocks;
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
    }
}
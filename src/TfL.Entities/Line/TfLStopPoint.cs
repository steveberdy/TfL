using System.Collections.Generic;
using Newtonsoft.Json;
using TfL.Converters;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-11
    /// </summary>
    public class TfLStopPoint
    {
        [JsonProperty("naptanId")]
        public string NaptanId { get; set; }
        [JsonProperty("platformName")]
        public string PlatformName { get; set; }
        [JsonProperty("indicator")]
        public string Indicator { get; set; }
        [JsonProperty("stopLetter")]
        public string StopLetter { get; set; }
        [JsonProperty("modes")]
        public string[] Modes { get; set; }
        [JsonProperty("icsCode")]
        public string IcsCode { get; set; }
        [JsonProperty("smsCode")]
        public string SmsCode { get; set; }
        [JsonProperty("stopType")]
        public string StopType { get; set; }
        [JsonProperty("stationNaptan")]
        public string StationNaptan { get; set; }
        [JsonProperty("accessibilitySummary")]
        public string AccessibilitySummary { get; set; }
        [JsonProperty("hubNaptanCode")]
        public string HubNaptanCode { get; set; }
        [JsonProperty("lines")]
        public TfLLine[] Lines { get; set; }
        [JsonProperty("lineGroup")]
        public TfLLineGroup[] LineGroups { get; set; }
        [JsonProperty("lineModeGroups")]
        public TfLLineModeGroup[] LineModeGroups { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("naptanMode")]
        public string NaptanMode { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("commonName")]
        public string CommonName { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("placeType")]
        public string PlaceType { get; set; }
        [JsonProperty("additionalProperties"), JsonConverter(typeof(TfLStopPointPropertyConverter))]
        public Dictionary<string, string[]> StationServices { get; set; }
        [JsonProperty("children")]
        public TfLStopPointChild[] Children { get; set; }
        [JsonProperty("childrenurls")]
        public string[] ChildrenUrls { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
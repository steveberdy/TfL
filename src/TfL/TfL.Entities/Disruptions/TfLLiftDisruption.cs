using Newtonsoft.Json;

namespace TfL.Entities
{
    public class TfLLiftDisruption
    {
        /// <summary>
        /// Ics code for the disrupted lift route
        /// </summary>
        [JsonProperty("icsCode")] public string IcsCode { get; set; }
        /// <summary>
        /// Naptan code for the stop area of the disrupted lift route
        /// </summary>
        [JsonProperty("naptanCode")] public string NaptanCode { get; set; }
        /// <summary>
        /// Name of the stop point of the disrupted lift route
        /// </summary>
        [JsonProperty("stopPointName")] public string StopPointName { get; set; }
        /// <summary>
        /// Id for the start of the disrupted lift route
        /// </summary>
        [JsonProperty("outageStartArea")] public string OutageStartArea { get; set; }
        /// <summary>
        /// Id for the end of the disrupted lift route
        /// </summary>
        [JsonProperty("outageEndArea")] public string OutageEndArea { get; set; }
        /// <summary>
        /// Customer facing message for the disrupted lift route
        /// </summary>
        [JsonProperty("message")] public string Message { get; set; }
    }
}
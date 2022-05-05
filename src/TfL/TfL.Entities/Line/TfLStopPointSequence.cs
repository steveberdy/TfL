using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-21
    /// </summary>
    public class TfLStopPointSequence
    {
        [JsonProperty("lineId")] public string LineId { get; set; }
        [JsonProperty("lineName")] public string LineName { get; set; }
        [JsonProperty("direction")] public TfLDirectionEnum Direction { get; set; }
        [JsonProperty("branchId")] public int BranchId { get; set; }
        [JsonProperty("nextBranchIds")] public int[] NextBranchIds { get; set; }
        [JsonProperty("prevBranchIds")] public int[] PreviousBranchIds { get; set; }
        [JsonProperty("stopPoint")] public TfLStation[] StopPoints { get; set; }
        [JsonProperty("serviceType")] public TfLServiceTypeEnum ServiceType { get; set; }
    }
}
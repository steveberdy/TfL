using Newtonsoft.Json;

namespace TfL.Entities
{
    /// <summary>
    /// Tfl-5
    /// </summary>
    public class TfLCrowding
    {
        [JsonProperty("passengerFlows")] public TfLPassengerFlow[] PassengerFlows { get; set; }
        [JsonProperty("trainLoadings")] public TfLTrainLoading[] TrainLoadings { get; set; }
    }
}
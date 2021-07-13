using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for air quality in London
    /// </summary>
    public class TfLAirQualityApi : TfLApi
    {
        protected override string UriPart => "AirQuality";

        internal TfLAirQualityApi(TfLClient client) : base(client) { }


        public Task<TfLAirQuality> GetAirQuality(CancellationToken token = default)
        {
            return GetAsync<TfLAirQuality>("", null, token);
        }
    }
}
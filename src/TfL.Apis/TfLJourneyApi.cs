using System;
using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for journey planning
    /// </summary>
    public class TfLJourneyApi : TfLApi
    {
        protected override string UriPart => "Journey";

        internal TfLJourneyApi(TfLClient client) : base(client) { }


        public Task<TfLMode[]> GetJourneyPlannerModes(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLMode[]>("Meta/Modes", null, cancellationToken);
        }

        #region JourneySearch
        #endregion
    }
}
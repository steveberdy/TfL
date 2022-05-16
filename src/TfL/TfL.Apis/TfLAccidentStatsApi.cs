using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for transport accident statistics
    /// </summary>
    public class TfLAccidentStatsApi : TfLApi
    {
        protected override string UriPart => "AccidentStats";

        internal TfLAccidentStatsApi(TfLClient client) : base(client) { }


        public Task<TfLAccidentStats[]> GetAccidentsAsync(int year, CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLAccidentStats[]>($"{year}", null, cancellationToken);
        }
    }
}
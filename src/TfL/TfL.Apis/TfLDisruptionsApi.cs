using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for transportation disruptions
    /// </summary>
    public class TfLDisruptionsApi : TfLApi
    {
        protected override string UriPart => "Disruptions";

        internal TfLDisruptionsApi(TfLClient client) : base(client) { }


        public Task<TfLLiftDisruption[]> GetDisruptions(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLLiftDisruption[]>("Lifts", null, cancellationToken);
        }
    }
}
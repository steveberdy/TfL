using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TfL.Apis
{
    public class TfLApi
    {
        protected TfLClient _client;
        protected virtual string UriPart { get; }

        internal TfLApi(TfLClient client)
        {
            _client = client;
        }

        protected Task<TResult> GetAsync<TResult>(string uriPath, Dictionary<string, object> query, CancellationToken cancellationToken = default)
        {
            return _client.GetAsync<TResult>($"{UriPart}/{uriPath}", query, cancellationToken);
        }
    }
}
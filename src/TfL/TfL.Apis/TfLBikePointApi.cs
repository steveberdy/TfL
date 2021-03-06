using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for bike lock areas
    /// </summary>
    public class TfLBikePointApi : TfLApi
    {
        protected override string UriPart => "BikePoint";

        internal TfLBikePointApi(TfLClient client) : base(client) { }

        /// <summary>
        /// Gets all bike points
        /// </summary>
        /// <returns>
        /// An array of all bike points
        /// </returns>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        public Task<TfLBikePointPlace[]> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLBikePointPlace[]>("", null, cancellationToken);
        }

        /// <summary>
        /// Gets the bike point with the given id
        /// </summary>
        /// <returns>
        /// A bike point with the given id
        /// </returns>
        /// <param name="bikePointId">A bike point id</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">bikePointId is null or empty</exception>
        public Task<TfLBikePointPlace> GetAsync(string bikePointId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(bikePointId))
            {
                throw new ArgumentNullException(nameof(bikePointId));
            }

            return GetAsync<TfLBikePointPlace>(bikePointId, null, cancellationToken);
        }

        /// <summary>
        /// Searches for bike points by name.
        /// Note that information only includes place information,
        /// not stats about the bike point. Use <see cref="GetAsync"/> to get
        /// such information.
        /// </summary>
        /// <returns>
        /// An array of matching bike points
        /// </returns>
        /// <param name="search">Search query</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">search is null or empty</exception>
        public Task<TfLBikePointPlace[]> SearchAsync(string search, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            var query = new Dictionary<string, object>
            {
                { "query", search }
            };

            return GetAsync<TfLBikePointPlace[]>("Search", query, cancellationToken);
        }
    }
}
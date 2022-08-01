using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using TfL.Apis;

namespace TfL
{
    /// <summary>
    /// A client for all Transport for London APIs
    /// </summary>
    public class TfLClient : IDisposable
    {
        private static readonly string baseUrl = "https://api.tfl.gov.uk/";
        private readonly HttpClient client;
        private readonly JsonSerializer serializer;

        /// <summary>
        /// Line API
        /// </summary>
        public TfLLineApi Line;
        /// <summary>
        /// AccidentStats API
        /// </summary>
        public TfLAccidentStatsApi AccidentStats;
        /// <summary>
        /// AirQuality API
        /// </summary>
        public TfLAirQualityApi AirQuality;
        /// <summary>
        /// BikePoint API
        /// </summary>
        public TfLBikePointApi BikePoint;
        /// <summary>
        /// Lift Disruptions API
        /// </summary>
        public TfLDisruptionsApi Disruptions;


        /// <summary>
        /// Creates a new <see cref="TfLClient"/>.
        /// </summary>
        public TfLClient()
        {
            Line = new TfLLineApi(this);
            AccidentStats = new TfLAccidentStatsApi(this);
            AirQuality = new TfLAirQualityApi(this);
            BikePoint = new TfLBikePointApi(this);
            Disruptions = new TfLDisruptionsApi(this);

            client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }, true);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(baseUrl);
            serializer = new JsonSerializer();
        }

        internal async Task<TResult> GetAsync<TResult>(string uriPath, Dictionary<string, object> query, CancellationToken cancellationToken = default)
        {
            uriPath += Utils.CreateQuery(query);

            try
            {
                var response = await client.GetAsync(uriPath, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using var jtr = new JsonTextReader(
                        new StreamReader(await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false)))
                    { CloseInput = true };
                    return serializer.Deserialize<TResult>(jtr);
                }
            }
            catch { }


            // If it's not a success, return default instead of throwing an error
            return default;
        }

        /// <summary>
        /// Disposes this TfLClient
        /// </summary>
        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
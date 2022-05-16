using System;
using System.Threading.Tasks;
using System.Threading;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for station crowding information.
    /// App key required
    /// </summary>
    public class TfLCrowdingApi : TfLApi
    {
        protected override string UriPart => "Crowding";

        internal TfLCrowdingApi(TfLClient client) : base(client) { }

        private void CheckAuthorization()
        {
            if (!_client.HasAppKey)
            {
                throw new UnauthorizedAccessException("To access the Crowding API, you need an app key.");
            }
        }


        #region GetDayOfWeekCrowding
        
        public Task<object> GetDayOfWeekCrowdingAsync(string naptanCode, DayOfWeek dayOfWeek, CancellationToken cancellationToken = default)
        {
            CheckAuthorization();

            if (string.IsNullOrEmpty(naptanCode))
            {
                throw new ArgumentNullException(nameof(naptanCode));
            }

            var path = naptanCode + "/" + dayOfWeek.ToString();
            return GetAsync<object>(path, null, cancellationToken);
        }

        public Task<object> GetDayOfWeekCrowdingAsync(string naptanCode, string dayOfWeek, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(dayOfWeek, true, out DayOfWeek day))
            {
                return GetDayOfWeekCrowdingAsync(naptanCode, day, cancellationToken);
            }

            throw new ArgumentException($"{nameof(dayOfWeek)} must be a valid day of the week.");
        }

        #endregion

        #region GetLiveCrowding
        
        public Task<object> GetLiveCrowdingAsync(string naptanCode, CancellationToken cancellationToken = default)
        {
            CheckAuthorization();

            if (string.IsNullOrEmpty(naptanCode))
            {
                throw new ArgumentNullException(nameof(naptanCode));
            }

            return GetAsync<object>($"{naptanCode}/Live", null, cancellationToken);
        }

        #endregion

        #region GetCrowding

        public Task<object> GetCrowdingAsync(string naptanCode, CancellationToken cancellationToken = default)
        {
            CheckAuthorization();

            if (string.IsNullOrEmpty(naptanCode))
            {
                throw new ArgumentNullException(nameof(naptanCode));
            }

            return GetAsync<object>(naptanCode, null, cancellationToken);
        }

        #endregion
    }
}
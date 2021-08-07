using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using TfL.Entities;

namespace TfL.Apis
{
    /// <summary>
    /// API for line and station information
    /// </summary>
    public class TfLLineApi : TfLApi
    {
        protected override string UriPart => "Line";

        internal TfLLineApi(TfLClient client) : base(client) { }


        #region GetAllRoutes

        public Task<TfLRoutes[]> GetAllRoutes(string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetAllRoutes(serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetAllRoutes(TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>
            {
                { "serviceTypes", Utils.GetServiceTypeString(serviceType) }
            };

            return GetAsync<TfLRoutes[]>("Route", query, cancellationToken);
        }

        #endregion

        #region GetRoutes

        public Task<TfLRoutes[]> GetRoutes(string lineId, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutes(lineId, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutes(string lineId, TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetRoutes(new[] { lineId }, serviceType, cancellationToken);
        }

        public Task<TfLRoutes[]> GetRoutes(IEnumerable<string> lineIds, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutes(lineIds, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutes(IEnumerable<string> lineIds, TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            var path = string.Join(",", lineIds) + "/Route";
            var query = new Dictionary<string, object>
            {
                { "serviceTypes", Utils.GetServiceTypeString(serviceType) }
            };

            return GetAsync<TfLRoutes[]>(path, query, cancellationToken);
        }

        #endregion

        #region GetMainRoute

        public Task<TfLRoutes> GetMainRoute(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetAsync<TfLRoutes>($"{lineId}/Route", null, cancellationToken);
        }

        #endregion

        #region GetAllDisruptions

        public Task<TfLDisruption[]> GetAllDisruptions(string mode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetAllDisruptions(new[] { mode }, cancellationToken);
        }

        public Task<TfLDisruption[]> GetAllDisruptions(IEnumerable<string> modes, CancellationToken cancellationToken = default)
        {
            if (!modes.Any() || modes.Contains(null) || modes.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(modes));
            }

            var path = "Mode/" + string.Join(",", modes) + "/Disruption";
            return GetAsync<TfLDisruption[]>(path, null, cancellationToken);
        }

        #endregion

        #region GetDisruptions

        public Task<TfLDisruption[]> GetDisruptions(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetDisruptions(new[] { lineId }, cancellationToken);
        }

        public Task<TfLDisruption[]> GetDisruptions(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            var path = string.Join(",", lineIds) + "/Disruption";
            return GetAsync<TfLDisruption[]>(path, null, cancellationToken);
        }

        #endregion

        #region GetLineArrivals

        public Task<TfLArrival[]> GetLineArrivals(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineArrivals(new[] { lineId }, cancellationToken);
        }

        public Task<TfLArrival[]> GetLineArrivals(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            var path = string.Join(",", lineIds) + "/Arrivals";
            return GetAsync<TfLArrival[]>(path, null, cancellationToken);
        }

        #endregion

        #region GetStopArrivals

        public Task<TfLArrival[]> GetStopArrivals(string lineId, string stopPointId = null, string direction = null,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetStopArrivals(new[] { lineId }, stopPointId, direction, destinationStationId, cancellationToken);
        }

        public Task<TfLArrival[]> GetStopArrivals(string lineId, string stopPointId = null, TfLDirectionEnum direction = default,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            return GetStopArrivals(lineId, stopPointId, direction.ToString(), destinationStationId, cancellationToken);
        }

        public Task<TfLArrival[]> GetStopArrivals(IEnumerable<string> lineIds, string stopPointId = null, string direction = null,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            var path = string.Join(",", lineIds) + "/Arrivals" + (stopPointId == null ? "" : "/" + stopPointId);
            var query = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(direction))
            {
                query.Add("direction", direction);
            }
            if (!string.IsNullOrEmpty(destinationStationId))
            {
                query.Add("destinationStationId", destinationStationId);
            }

            return GetAsync<TfLArrival[]>(path, query, cancellationToken);
        }

        public Task<TfLArrival[]> GetStopArrivals(IEnumerable<string> lineIds, string stopPointId = null, TfLDirectionEnum direction = default,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            return GetStopArrivals(lineIds, stopPointId, direction.ToString(), destinationStationId, cancellationToken);
        }

        #endregion

        #region GetLineStations

        public Task<TfLStopPoint[]> GetLineStations(string lineId, bool tflOnly = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            var query = new Dictionary<string, object>
            {
                { "tflOperatedNationalRailStationsOnly", tflOnly }
            };

            return GetAsync<TfLStopPoint[]>($"{lineId}/StopPoints", query, cancellationToken);
        }

        #endregion

        #region Meta

        public Task<string[]> GetValidDisruptionCategories(CancellationToken cancellationToken = default)
        {
            return GetAsync<string[]>("Meta/DisruptionCategories", null, cancellationToken);
        }

        public Task<TfLMode[]> GetValidModes(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLMode[]>("Meta/Modes", null, cancellationToken);
        }

        /// <summary>
        /// Gets valid service types.
        /// Also represented by <see cref="TfLServiceTypeEnum"/>
        /// </summary>
        public Task<string[]> GetValidServiceTypes(CancellationToken cancellationToken = default)
        {
            return GetAsync<string[]>("Meta/ServiceTypes", null, cancellationToken);
        }

        public Task<TfLSeverityCode[]> GetValidSeverityCodes(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLSeverityCode[]>("Meta/Severity", null, cancellationToken);
        }

        #endregion

        #region GetRoutesByMode

        public Task<TfLRoutes[]> GetRoutesByMode(string mode, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesByMode(mode, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutesByMode(string mode, TfLServiceTypeEnum serviceType, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetRoutesByMode(new[] { mode }, serviceType, cancellationToken);
        }

        public Task<TfLRoutes[]> GetRoutesByMode(IEnumerable<string> modes, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesByMode(modes, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutesByMode(IEnumerable<string> modes, TfLServiceTypeEnum serviceType, CancellationToken cancellationToken = default)
        {
            if (!modes.Any() || modes.Contains(null) || modes.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(modes));
            }

            var path = "Mode/" + string.Join(",", modes) + "/Route";
            var query = new Dictionary<string, object>
            {
                { "serviceTypes", Utils.GetServiceTypeString(serviceType) }
            };

            return GetAsync<TfLRoutes[]>(path, query, cancellationToken);
        }

        #endregion

        #region GetRoutesAndStops

        public Task<TfLRoutesAndStops> GetRoutesAndStops(string lineId, string direction, string serviceType = null, bool excludeCrowding = false,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }
            if (string.IsNullOrEmpty(direction))
            {
                throw new ArgumentNullException(nameof(direction));
            }

            var query = new Dictionary<string, object>
            {
                { "excludeCrowding", excludeCrowding }
            };
            if (!string.IsNullOrEmpty(serviceType))
            {
                query.Add("serviceTypes", serviceType);
            }

            return GetAsync<TfLRoutesAndStops>($"{lineId}/Route/Sequence/{direction}", query, cancellationToken);
        }

        public Task<TfLRoutesAndStops> GetRoutesAndStops(string lineId, TfLDirectionEnum direction, string serviceType = null, bool excludeCrowding = false,
            CancellationToken cancellationToken = default)
        {
            if (direction == TfLDirectionEnum.All)
            {
                throw new ArgumentException($"{nameof(direction)} cannot be TfLDirectionEnum.All for this method.");
            }

            return GetRoutesAndStops(lineId, direction.ToString(), serviceType, excludeCrowding, cancellationToken);
        }

        public Task<TfLRoutesAndStops> GetRoutesAndStops(string lineId, string direction, TfLServiceTypeEnum serviceType = default, bool excludeCrowding = false,
            CancellationToken cancellationToken = default)
        {
            return GetRoutesAndStops(lineId, direction, Utils.GetServiceTypeString(serviceType), excludeCrowding, cancellationToken);
        }

        public Task<TfLRoutesAndStops> GetRoutesAndStops(string lineId, TfLDirectionEnum direction, TfLServiceTypeEnum serviceType = default,
            bool excludeCrowding = false, CancellationToken cancellationToken = default)
        {
            return GetRoutesAndStops(lineId, direction, Utils.GetServiceTypeString(serviceType), excludeCrowding, cancellationToken);
        }

        #endregion

        #region GetLines

        public Task<TfLRoutes[]> GetLines(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLines(new[] { lineId }, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLines(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            return GetAsync<TfLRoutes[]>(string.Join(",", lineIds), null, cancellationToken);
        }

        #endregion

        #region GetLinesByMode

        public Task<TfLRoutes[]> GetLinesByMode(string mode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetLinesByMode(new[] { mode }, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLinesByMode(IEnumerable<string> modes, CancellationToken cancellationToken = default)
        {
            if (!modes.Any() || modes.Contains(null) || modes.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(modes));
            }

            var path = "Mode/" + string.Join(",", modes);
            return GetAsync<TfLRoutes[]>(path, null, cancellationToken);
        }

        #endregion

        #region GetLineStatusesBySeverity

        public Task<TfLRoutes[]> GetLineStatusesBySeverity(int severity, CancellationToken cancellationToken = default)
        {
            if (severity < 0 || severity > 14)
            {
                throw new ArgumentException($"{nameof(severity)} should be between 0 and 14.");
            }

            return GetAsync<TfLRoutes[]>($"Status/{severity}", null, cancellationToken);
        }

        #endregion

        #region GetLineStatusesByTimePeriod

        public Task<TfLRoutes[]> GetLineStatusesByTimePeriod(string lineId, DateTime startDate, DateTime endDate, bool detail = false,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineStatusesByTimePeriod(new[] { lineId }, startDate, endDate, detail, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatusesByTimePeriod(IEnumerable<string> lineIds, DateTime startDate, DateTime endDate, bool detail = false,
            CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }
            if (startDate == default)
            {
                throw new ArgumentException($"{nameof(startDate)} cannot be default.");
            }
            if (endDate == default)
            {
                throw new ArgumentException($"{nameof(endDate)} cannot be default.");
            }

            var path = string.Join(",", lineIds) + "/Status/" + startDate.UrlFormat() + "/to/" + startDate.UrlFormat();
            var query = new Dictionary<string, object>
            {
                { "detail", detail }
            };

            return GetAsync<TfLRoutes[]>(path, query, cancellationToken);
        }

        #endregion

        #region GetLineStatusesByMode

        public Task<TfLRoutes[]> GetLineStatusesByMode(string mode, bool detail = false, string severityLevel = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetLineStatusesByMode(new[] { mode }, detail, severityLevel, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatusesByMode(IEnumerable<string> modes, bool detail = false, string severityLevel = null,
            CancellationToken cancellationToken = default)
        {
            if (!modes.Any() || modes.Contains(null) || modes.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(modes));
            }

            var path = "Mode/" + string.Join(",", modes) + "/Status";
            var query = new Dictionary<string, object>
            {
                { "detail", detail }
            };
            if (!string.IsNullOrEmpty(severityLevel))
            {
                query.Add("severityLevel", severityLevel);
            }

            return GetAsync<TfLRoutes[]>(path, query, cancellationToken);
        }

        #endregion

        #region GetLineStatuses

        public Task<TfLRoutes[]> GetLineStatuses(string lineId, bool detail = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineStatuses(new[] { lineId }, detail, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatuses(IEnumerable<string> lineIds, bool detail = false, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            var path = string.Join(",", lineIds) + "/Status";
            var query = new Dictionary<string, object>
            {
                { "detail", detail }
            };

            return GetAsync<TfLRoutes[]>(path, query, cancellationToken);
        }

        #endregion

        #region GetTimetableByStation

        public Task<TfLStationTimetable> GetTimetableByStation(string lineId, string fromStopPointId, string toStopPointId = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }
            if (string.IsNullOrEmpty(fromStopPointId))
            {
                throw new ArgumentNullException(nameof(fromStopPointId));
            }

            var path = $"{lineId}/Timetable/{fromStopPointId}";
            if (!string.IsNullOrEmpty(toStopPointId))
            {
                path += $"/to/{toStopPointId}";
            }

            return GetAsync<TfLStationTimetable>(path, null, cancellationToken);
        }

        #endregion

        #region Search

        public Task<TfLSearchResult> Search(string search, IEnumerable<string> modes = null, string serviceType = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            var query = new Dictionary<string, object>();
            if (modes != null)
            {
                query.Add("modes", modes);
            }
            if (!string.IsNullOrEmpty(serviceType))
            {
                query.Add("serviceTypes", serviceType);
            }

            return GetAsync<TfLSearchResult>($"Search/{search}", query, cancellationToken);
        }

        public Task<TfLSearchResult> Search(string search, IEnumerable<string> modes = null, TfLServiceTypeEnum serviceType = default,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            return Search(search, modes, Utils.GetServiceTypeString(serviceType), cancellationToken);
        }

        #endregion
    }
}
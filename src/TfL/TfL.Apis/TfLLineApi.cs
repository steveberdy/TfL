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

        /// <summary>
        /// Get all valid routes for all lines.
        /// Uses a serviceType string, which may be Regular, Night, or
        /// both (Regular,Night)
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="serviceType">Service type string</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentException">serviceType must be a valid service type</exception>
        public Task<TfLRoutes[]> GetAllRoutesAsync(string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetAllRoutesAsync(serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        /// <summary>
        /// Get all valid routes for all lines
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="serviceType">Service type enum</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        public Task<TfLRoutes[]> GetAllRoutesAsync(TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>
            {
                { "serviceTypes", Utils.GetServiceTypeString(serviceType) }
            };

            return GetAsync<TfLRoutes[]>("Route", query, cancellationToken);
        }

        #endregion

        #region GetRoutes

        /// <summary>
        /// Get all valid routes for the given line id.
        /// Uses a serviceType string, which may be Regular, Night, or
        /// both (Regular,Night)
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="lineId">Line id</param>
        /// <param name="serviceType">Service type string</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentException">serviceType must be a valid service type</exception>
        public Task<TfLRoutes[]> GetRoutesAsync(string lineId, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesAsync(lineId, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        /// <summary>
        /// Get all valid routes for the given line id
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="lineId">Line id</param>
        /// <param name="serviceType">Service type enum</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">lineId cannot be null or empty</exception>
        public Task<TfLRoutes[]> GetRoutesAsync(string lineId, TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetRoutesAsync(new[] { lineId }, serviceType, cancellationToken);
        }

        /// <summary>
        /// Get all valid routes for the given line ids.
        /// Uses a serviceType string, which may be Regular, Night, or
        /// both (Regular,Night)
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="lineIds">Line id enumerable</param>
        /// <param name="serviceType">Service type string</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentException">serviceType must be a valid service type</exception>
        public Task<TfLRoutes[]> GetRoutesAsync(IEnumerable<string> lineIds, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesAsync(lineIds, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        /// <summary>
        /// Get all valid routes for the given line ids
        /// </summary>
        /// <returns>An array of routes</returns>
        /// <param name="lineIds">Line id enumerable</param>
        /// <param name="serviceType">Service type enum</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">lineIds cannot be null or empty or contain null or empty line ids</exception>
        public Task<TfLRoutes[]> GetRoutesAsync(IEnumerable<string> lineIds, TfLServiceTypeEnum serviceType = default, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Gets the main route for the given line id
        /// </summary>
        /// <returns>The main route for the line</returns>
        /// <param name="lineId">Line id</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">lineId cannot be null or empty</exception>
        public Task<TfLRoutes> GetMainRouteAsync(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetAsync<TfLRoutes>($"{lineId}/Route", null, cancellationToken);
        }

        #endregion

        #region GetAllDisruptions

        /// <summary>
        /// Gets all disruptions for the given mode of transportation.
        /// Use 'GetValidModes' for a list of modes that are usable
        /// </summary>
        /// <returns>An array of disruptions for the mode of transportation</returns>
        /// <param name="mode">Mode of transporation</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">mode cannot be null or empty</exception>
        public Task<TfLDisruption[]> GetAllDisruptionsAsync(string mode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetAllDisruptionsAsync(new[] { mode }, cancellationToken);
        }

        /// <summary>
        /// Gets all disruptions for the given modes of transportation.
        /// Use 'GetValidModes' for a list of modes that are usable
        /// </summary>
        /// <returns>An array of disruptions for the mode of transportation</returns>
        /// <param name="modes">Enumerable for modes of transporation</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">modes cannot be null or empty or contain null or empty modes</exception>
        public Task<TfLDisruption[]> GetAllDisruptionsAsync(IEnumerable<string> modes, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Gets all disruptions for the given line
        /// </summary>
        /// <returns>An array of disruptions for the line provided</returns>
        /// <param name="lineId">Line id</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">lineId cannot be null or empty</exception>
        public Task<TfLDisruption[]> GetDisruptionsAsync(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetDisruptionsAsync(new[] { lineId }, cancellationToken);
        }

        /// <summary>
        /// Gets all disruptions for the given lines
        /// </summary>
        /// <returns>An array of disruptions for the lines provided</returns>
        /// <param name="lineIds">Line id enumerable</param>
        /// <param name="cancellationToken">Cancellation token, optional</param>
        /// <exception cref="ArgumentNullException">lineIds cannot be null or empty or contain null or empty line ids</exception>
        public Task<TfLDisruption[]> GetDisruptionsAsync(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
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

        public Task<TfLArrival[]> GetLineArrivalsAsync(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineArrivalsAsync(new[] { lineId }, cancellationToken);
        }

        public Task<TfLArrival[]> GetLineArrivalsAsync(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
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

        public Task<TfLArrival[]> GetStopArrivalsAsync(string lineId, string stopPointId = null, string direction = null,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetStopArrivalsAsync(new[] { lineId }, stopPointId, direction, destinationStationId, cancellationToken);
        }

        public Task<TfLArrival[]> GetStopArrivalsAsync(string lineId, string stopPointId = null, TfLDirectionEnum direction = default,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            return GetStopArrivalsAsync(lineId, stopPointId, direction.ToString(), destinationStationId, cancellationToken);
        }

        public Task<TfLArrival[]> GetStopArrivalsAsync(IEnumerable<string> lineIds, string stopPointId = null, string direction = null,
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

        public Task<TfLArrival[]> GetStopArrivalsAsync(IEnumerable<string> lineIds, string stopPointId = null, TfLDirectionEnum direction = default,
            string destinationStationId = null, CancellationToken cancellationToken = default)
        {
            return GetStopArrivalsAsync(lineIds, stopPointId, direction.ToString(), destinationStationId, cancellationToken);
        }

        #endregion

        #region GetLineStations

        public Task<TfLStopPoint[]> GetLineStationsAsync(string lineId, bool tflOnly = false, CancellationToken cancellationToken = default)
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

        public Task<string[]> GetValidDisruptionCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<string[]>("Meta/DisruptionCategories", null, cancellationToken);
        }

        public Task<TfLMode[]> GetValidModesAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLMode[]>("Meta/Modes", null, cancellationToken);
        }

        /// <summary>
        /// Gets valid service types.
        /// Also represented by <see cref="TfLServiceTypeEnum"/>
        /// </summary>
        public Task<string[]> GetValidServiceTypesAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<string[]>("Meta/ServiceTypes", null, cancellationToken);
        }

        public Task<TfLSeverityCode[]> GetValidSeverityCodesAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<TfLSeverityCode[]>("Meta/Severity", null, cancellationToken);
        }

        #endregion

        #region GetRoutesByMode

        public Task<TfLRoutes[]> GetRoutesByModeAsync(string mode, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesByModeAsync(mode, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutesByModeAsync(string mode, TfLServiceTypeEnum serviceType, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetRoutesByModeAsync(new[] { mode }, serviceType, cancellationToken);
        }

        public Task<TfLRoutes[]> GetRoutesByModeAsync(IEnumerable<string> modes, string serviceType, CancellationToken cancellationToken = default)
        {
            if (Enum.TryParse(serviceType, true, out TfLServiceTypeEnum serviceTypeEnum))
            {
                return GetRoutesByModeAsync(modes, serviceTypeEnum, cancellationToken);
            }

            throw new ArgumentException($"{nameof(serviceType)} must be a valid service type.");
        }

        public Task<TfLRoutes[]> GetRoutesByModeAsync(IEnumerable<string> modes, TfLServiceTypeEnum serviceType, CancellationToken cancellationToken = default)
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

        public Task<TfLRoutesAndStops> GetRoutesAndStopsAsync(string lineId, string direction, string serviceType = null, bool excludeCrowding = false,
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

        public Task<TfLRoutesAndStops> GetRoutesAndStopsAsync(string lineId, TfLDirectionEnum direction, string serviceType = null, bool excludeCrowding = false,
            CancellationToken cancellationToken = default)
        {
            if (direction == TfLDirectionEnum.All)
            {
                throw new ArgumentException($"{nameof(direction)} cannot be TfLDirectionEnum.All for this method.");
            }

            return GetRoutesAndStopsAsync(lineId, direction.ToString(), serviceType, excludeCrowding, cancellationToken);
        }

        public Task<TfLRoutesAndStops> GetRoutesAndStopsAsync(string lineId, string direction, TfLServiceTypeEnum serviceType = default, bool excludeCrowding = false,
            CancellationToken cancellationToken = default)
        {
            return GetRoutesAndStopsAsync(lineId, direction, Utils.GetServiceTypeString(serviceType), excludeCrowding, cancellationToken);
        }

        public Task<TfLRoutesAndStops> GetRoutesAndStopsAsync(string lineId, TfLDirectionEnum direction, TfLServiceTypeEnum serviceType = default,
            bool excludeCrowding = false, CancellationToken cancellationToken = default)
        {
            return GetRoutesAndStopsAsync(lineId, direction, Utils.GetServiceTypeString(serviceType), excludeCrowding, cancellationToken);
        }

        #endregion

        #region GetLines

        public Task<TfLRoutes[]> GetLinesAsync(string lineId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLinesAsync(new[] { lineId }, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLinesAsync(IEnumerable<string> lineIds, CancellationToken cancellationToken = default)
        {
            if (!lineIds.Any() || lineIds.Contains(null) || lineIds.Contains(string.Empty))
            {
                throw new ArgumentNullException(nameof(lineIds));
            }

            return GetAsync<TfLRoutes[]>(string.Join(",", lineIds), null, cancellationToken);
        }

        #endregion

        #region GetLinesByMode

        public Task<TfLRoutes[]> GetLinesByModeAsync(string mode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetLinesByModeAsync(new[] { mode }, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLinesByModeAsync(IEnumerable<string> modes, CancellationToken cancellationToken = default)
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

        public Task<TfLRoutes[]> GetLineStatusesBySeverityAsync(int severity, CancellationToken cancellationToken = default)
        {
            if (severity < 0 || severity > 14)
            {
                throw new ArgumentException($"{nameof(severity)} should be between 0 and 14.");
            }

            return GetAsync<TfLRoutes[]>($"Status/{severity}", null, cancellationToken);
        }

        #endregion

        #region GetLineStatusesByTimePeriod

        public Task<TfLRoutes[]> GetLineStatusesByTimePeriodAsync(string lineId, DateTime startDate, DateTime endDate, bool detail = false,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineStatusesByTimePeriodAsync(new[] { lineId }, startDate, endDate, detail, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatusesByTimePeriodAsync(IEnumerable<string> lineIds, DateTime startDate, DateTime endDate, bool detail = false,
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

        public Task<TfLRoutes[]> GetLineStatusesByModeAsync(string mode, bool detail = false, string severityLevel = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentNullException(nameof(mode));
            }

            return GetLineStatusesByModeAsync(new[] { mode }, detail, severityLevel, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatusesByModeAsync(IEnumerable<string> modes, bool detail = false, string severityLevel = null,
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

        public Task<TfLRoutes[]> GetLineStatusesAsync(string lineId, bool detail = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(lineId))
            {
                throw new ArgumentNullException(nameof(lineId));
            }

            return GetLineStatusesAsync(new[] { lineId }, detail, cancellationToken);
        }

        public Task<TfLRoutes[]> GetLineStatusesAsync(IEnumerable<string> lineIds, bool detail = false, CancellationToken cancellationToken = default)
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

        public Task<TfLStationTimetable> GetTimetableByStationAsync(string lineId, string fromStopPointId, string toStopPointId = null,
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

        public Task<TfLSearchResult> SearchAsync(string search, IEnumerable<string> modes = null, string serviceType = null, CancellationToken cancellationToken = default)
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

        public Task<TfLSearchResult> SearchAsync(string search, IEnumerable<string> modes = null, TfLServiceTypeEnum serviceType = default,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            return SearchAsync(search, modes, Utils.GetServiceTypeString(serviceType), cancellationToken);
        }

        #endregion
    }
}
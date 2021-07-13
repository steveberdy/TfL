using System;
using System.Linq;
using System.Collections.Generic;

namespace TfL
{
    public static class Utils
    {
        private static readonly DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string CreateQuery(Dictionary<string, object> dict)
        {
            if (dict != null && dict.Count > 0)
            {
                return "?" + string.Join("&", dict.Keys.Select(x =>
                {
                    if (dict[x] is IEnumerable<object> e)
                    {
                        return $"{x}=" + string.Join(",", e);
                    }
                    return $"{x}={dict[x]}";
                }));
            }
            return string.Empty;
        }

        public static string GetServiceTypeString(TfLServiceTypeEnum serviceType)
        {
            return serviceType switch
            {
                TfLServiceTypeEnum.Night => "Night",
                TfLServiceTypeEnum.Both => "Regular,Night",
                _ => "Regular",
            };
        }

        public static string UrlFormat(this DateTime date)
        {
            return date.ToString("yyyyMMddTHH:mm:ssZ");
        }

        public static DateTime FromUnixTimestampStringMs(string timestamp)
        {
            if (string.IsNullOrEmpty(timestamp))
            {
                return default;
            }

            return FromUnixTimestampMs(long.Parse(timestamp));
        }

        public static DateTime FromUnixTimestampMs(long timestamp)
        {
            return epoch.AddMilliseconds(timestamp);
        }
    }
}
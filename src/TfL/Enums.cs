using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace TfL
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TfLServiceTypeEnum
    {
        [EnumMember(Value = "Regular")]
        Regular = 0,
        [EnumMember(Value = "Night")]
        Night = 1,
        Both = 2
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TfLDirectionEnum
    {
        [EnumMember(Value = "all")]
        All = 0,
        [EnumMember(Value = "inbound")]
        Inbound = 1,
        [EnumMember(Value = "outbound")]
        Outbound = 2
    }
}

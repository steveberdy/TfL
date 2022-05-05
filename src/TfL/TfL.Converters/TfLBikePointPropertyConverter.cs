using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TfL.Entities;

namespace TfL.Converters
{
    public class TfLBikePointPropertyConverter : JsonConverter<TfLBikePoint>
    {
        public override void WriteJson(JsonWriter writer, TfLBikePoint value, JsonSerializer serializer)
        {
            writer.WriteRawValue(JsonConvert.SerializeObject(value));
        }

        public override TfLBikePoint ReadJson(JsonReader reader, Type objectType, TfLBikePoint existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader).Children().Select(x => x.ToObject<TfLBikePointProperty>()).ToArray();
            if (array.Length == 0)
            {
                return null;
            }

            return new TfLBikePoint
            {
                TerminalName = array[0].Value,
                Installed = bool.Parse(array[1].Value),
                Locked = bool.TryParse(array[2].Value, out bool b2) ? b2 : null,
                InstallDate = Utils.FromUnixTimestampStringMs(array[3].Value),
                RemovalDate = Utils.FromUnixTimestampStringMs(array[4].Value),
                Temporary = bool.TryParse(array[5].Value, out bool b5) ? b5: null,
                Bikes = int.Parse(array[6].Value),
                EmptyDocks = int.Parse(array[7].Value),
                TotalDocks = int.Parse(array[8].Value),
                Modified = array[0].Modified
            };
        }
    }
}
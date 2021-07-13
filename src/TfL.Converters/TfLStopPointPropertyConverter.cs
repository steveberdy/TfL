using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TfL.Entities;

namespace TfL.Converters
{
    public class TfLStopPointPropertyConverter : JsonConverter<Dictionary<string, string[]>>
    {
        public override void WriteJson(JsonWriter writer, Dictionary<string, string[]> value, JsonSerializer serializer)
        {
            writer.WriteRawValue(JsonConvert.SerializeObject(value));
        }

        public override Dictionary<string, string[]> ReadJson(JsonReader reader, Type objectType, Dictionary<string, string[]> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return JArray.Load(reader).Children().Select(x => x.ToObject<TfLStopPointProperty>())
                .Aggregate(new List<List<TfLStopPointProperty>>(), (a, b) =>
                {
                    var chunk = a.FirstOrDefault(x => x[0].Key == b.Key);
                    if (chunk != null)
                    {
                        chunk.Add(b);
                    }
                    else
                    {
                        a.Add(new List<TfLStopPointProperty> { b });
                    }
                    return a;
                })
                .ToDictionary(x => x[0].Key, x => x.Select(x => x.Value).ToArray());
        }
    }
}
using System;
using Newtonsoft.Json;

namespace TfL.Converters
{
    public class TfLForecastTextConverter : JsonConverter<string>
    {
        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString()
                .Replace("&lt;br/&gt;", "\n")
                .Replace("&#39;", "'")
                .Trim();
        }
    }
}
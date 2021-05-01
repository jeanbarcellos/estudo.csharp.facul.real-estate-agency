using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RealEstateAgency.Core.Serialization
{
    public class JsonDateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options)
        {
            writer.WriteStringValue(dateTimeValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}

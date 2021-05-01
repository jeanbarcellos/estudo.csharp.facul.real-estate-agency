using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RealEstateAgency.Core.Serialization
{
    public class JsonNullableDateConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() == "")
                return null;
            else
                return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        // This method will be ignored on serialization, and the default typeof(DateTime) converter is used instead.
        // This is a bug: https://github.com/dotnet/corefx/issues/41070#issuecomment-560949493
        public override void Write(Utf8JsonWriter writer, DateTime? dateTimeValue, JsonSerializerOptions options)
        {
            if (!dateTimeValue.HasValue)
            {
                writer.WriteStringValue("");
            }
            else
            {
                writer.WriteStringValue(dateTimeValue?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }
        }
    }
}

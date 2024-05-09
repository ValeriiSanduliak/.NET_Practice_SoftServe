using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CinemaAPI.Helpers
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var timeString = reader.GetString();
            var parts = timeString.Split(":");
            if (
                parts.Length == 2
                && int.TryParse(parts[0], out int hour)
                && int.TryParse(parts[1], out int minute)
            )
            {
                return new TimeOnly(hour, minute);
            }
            throw new JsonException($"Invalid TimeOnly value: {timeString}");
        }

        public override void Write(
            Utf8JsonWriter writer,
            TimeOnly value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

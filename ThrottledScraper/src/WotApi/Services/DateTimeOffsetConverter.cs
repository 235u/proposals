using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WotApi.Services
{
    public sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long seconds = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(seconds);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters
{
    internal class DecimalConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var t = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
            return t == typeof(decimal);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (Nullable.GetUnderlyingType(typeToConvert) != null)
            {
                return (JsonConverter)Activator.CreateInstance(typeof(NullableDecimalConverter))!;
            }

            return (JsonConverter)Activator.CreateInstance(typeof(DecimalConverter))!;
        }

        private class DecimalConverter : JsonConverter<decimal>
        {
            public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number) return reader.GetDecimal();
                if (reader.TokenType == JsonTokenType.String)
                {
                    var s = reader.GetString();
                    if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var d)) return d;
                }
                throw new JsonException("Invalid decimal value.");
            }

            public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
                => writer.WriteNumberValue(value);
        }

        private class NullableDecimalConverter : JsonConverter<decimal?>
        {
            public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return null;
                if (reader.TokenType == JsonTokenType.Number) return reader.GetDecimal();
                if (reader.TokenType == JsonTokenType.String)
                {
                    var s = reader.GetString();
                    if (string.IsNullOrWhiteSpace(s)) return null;
                    if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var d)) return d;
                    return null;
                }
                throw new JsonException("Invalid decimal value.");
            }

            public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
            {
                if (value == null) writer.WriteNullValue();
                else writer.WriteNumberValue(value.Value);
            }
        }
    }
}

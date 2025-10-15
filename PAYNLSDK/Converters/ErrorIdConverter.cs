using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Converters;

internal class ErrorIdConverter : JsonConverter
{
    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return targetType == typeof(int);
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            if (Nullable.GetUnderlyingType(typeToConvert) != null)
            {
                return null;
            }

            throw new JsonException("Cannot convert null to Int32.");
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32();
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            if (int.TryParse(value, out var parsed))
            {
                return parsed;
            }

            throw new JsonException($"Unexpected conversion '{value}' when parsing errorId.");
        }

        throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing errorId.");
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteNumberValue(Convert.ToInt32(value));
    }
}

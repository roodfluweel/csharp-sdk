using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Converters;

/// <summary>
/// A boolean json converter for System.Text.Json that supports numeric and string payloads.
/// </summary>
internal class BooleanConverter : JsonConverter
{
    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return targetType == typeof(bool);
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        bool? value = reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Number => reader.GetDouble() != 0d,
            JsonTokenType.String => ParseString(reader.GetString()),
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing boolean.")
        };

        if (Nullable.GetUnderlyingType(typeToConvert) != null)
        {
            return value;
        }

        if (!value.HasValue)
        {
            throw new JsonException("Cannot convert null to non-nullable boolean.");
        }

        return value.Value;
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteBooleanValue(Convert.ToBoolean(value));
    }

    private static bool? ParseString(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (bool.TryParse(value, out var boolResult))
        {
            return boolResult;
        }

        if (int.TryParse(value, out var intResult))
        {
            return intResult != 0;
        }

        throw new JsonException($"Unexpected value '{value}' when parsing boolean.");
    }
}

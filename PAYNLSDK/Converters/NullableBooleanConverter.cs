using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

/// <summary>
/// A nullable boolean json converter for System.Text.Json that supports numeric and string payloads.
/// </summary>
internal class NullableBooleanConverter : JsonConverter<bool?>
{
    public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Number => reader.GetDouble() != 0d,
            JsonTokenType.String => ParseString(reader.GetString()),
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing boolean.")
        };
    }

    public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteBooleanValue(value.Value);
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

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Utilities;

namespace PayNLSdk.Converters;

internal class DMYConverter : JsonConverter
{
    private const string Format = "dd-MM-yyyy";
    private static readonly string[] ParseFormats =
    {
        "d-M-yyyy", "dd-MM-yyyy",
        "d/M/yyyy", "dd/MM/yyyy"
    };

    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return targetType == typeof(DateTime);
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            if (Nullable.GetUnderlyingType(typeToConvert) != null)
            {
                return null;
            }

            throw new JsonException("Cannot convert null to DateTime.");
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            if (reader.TryGetDateTime(out var parsed))
            {
                EnsureSpecified(parsed);
                return parsed;
            }

            var raw = reader.GetString();
            if (ParameterValidator.IsEmpty(raw))
            {
                return null;
            }

            if (DateTime.TryParseExact(raw, ParseFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                return dateTime;
            }

            return null;
        }

        throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing date.");
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        if (value is DateTime dateTime)
        {
            EnsureSpecified(dateTime);
            writer.WriteStringValue(dateTime.ToString(Format, CultureInfo.InvariantCulture));
            return;
        }

        throw new JsonException("Expected value of type 'DateTime'.");
    }

    private static void EnsureSpecified(DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            throw new JsonException("Cannot convert date time with an unspecified kind");
        }
    }
}

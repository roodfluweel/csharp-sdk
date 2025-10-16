using PayNlSdk.Utilities;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

internal class YMDConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd";
    private static readonly string[] ParseFormats =
    {
        "yyyy-M-d", "yyyy-MM-dd",
        "yyyy/M/d", "yyyy/MM/dd"
    };

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
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
                throw new JsonException("Cannot convert empty string to DateTime.");
            }

            if (DateTime.TryParseExact(raw, ParseFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                return dateTime;
            }

            throw new JsonException($"Unable to parse '{raw}' as DateTime using YMD format.");
        }

        throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing date.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        EnsureSpecified(value);
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }

    private static void EnsureSpecified(DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            throw new JsonException("Cannot convert date time with an unspecified kind");
        }
    }
}

internal class NullableYMDConverter : JsonConverter<DateTime?>
{
    private const string Format = "yyyy-MM-dd";
    private static readonly string[] ParseFormats =
    {
        "yyyy-M-d", "yyyy-MM-dd",
        "yyyy/M/d", "yyyy/MM/dd"
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
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

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        EnsureSpecified(value.Value);
        writer.WriteStringValue(value.Value.ToString(Format, CultureInfo.InvariantCulture));
    }

    private static void EnsureSpecified(DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            throw new JsonException("Cannot convert date time with an unspecified kind");
        }
    }
}

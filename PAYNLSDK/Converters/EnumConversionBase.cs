using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

internal abstract class EnumConversionBase<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("Cannot convert null to enum.");
        }

        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing enum.");
        }

        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return default(T);
        }

        return (T)Enums.EnumUtil.ToEnum(value, typeof(T));
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(Enums.EnumUtil.ToEnumString(value, typeof(T)));
    }
}

internal abstract class NullableEnumConversionBase<T> : JsonConverter<T?> where T : struct, Enum
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing enum.");
        }

        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return (T)Enums.EnumUtil.ToEnum(value, typeof(T));
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(Enums.EnumUtil.ToEnumString(value, typeof(T)));
    }
}

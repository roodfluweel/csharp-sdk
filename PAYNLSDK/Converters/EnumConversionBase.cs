using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Converters;

internal abstract class EnumConversionBase : JsonConverter
{
    public abstract Type EnumType { get; }

    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return EnumType == targetType;
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            if (Nullable.GetUnderlyingType(typeToConvert) != null)
            {
                return null;
            }

            throw new JsonException("Cannot convert null to enum.");
        }

        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing enum.");
        }

        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return Nullable.GetUnderlyingType(typeToConvert) != null ? null : Activator.CreateInstance(EnumType);
        }

        return Enums.EnumUtil.ToEnum(value, EnumType);
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(Enums.EnumUtil.ToEnumString(value, EnumType));
    }
}

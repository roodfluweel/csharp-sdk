using PayNlSdk.Objects;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

internal class CountryOptionConverter : JsonConverter<CountryOptions>
{
    public override CountryOptions? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Unexpected token '{reader.TokenType}' when parsing country options.");
        }

        var data = JsonSerializer.Deserialize<Dictionary<string, CountryOption>>(ref reader, options);
        if (data == null)
        {
            return new CountryOptions();
        }

        var result = new CountryOptions();
        foreach (var pair in data)
        {
            result[pair.Key] = pair.Value;
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, CountryOptions value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, new Dictionary<string, CountryOption>(value), options);
    }
}

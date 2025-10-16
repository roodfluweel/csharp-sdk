using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

/// <summary>
/// A factory for creating boolean json converters for System.Text.Json that support numeric and string payloads.
/// </summary>
internal class BooleanConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return targetType == typeof(bool);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (Nullable.GetUnderlyingType(typeToConvert) != null)
        {
            return new NullableBooleanConverter();
        }

        return new BooleanConverter();
    }
}

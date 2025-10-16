using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Converters;

/// <summary>
/// A factory for creating ErrorId converters for System.Text.Json.
/// </summary>
internal class ErrorIdConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        var targetType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return targetType == typeof(int);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (Nullable.GetUnderlyingType(typeToConvert) != null)
        {
            return new NullableErrorIdConverter();
        }

        return new ErrorIdConverter();
    }
}

using PayNlSdk.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Utilities;

internal static class JsonSerialization
{
    public static JsonSerializerOptions DefaultOptions { get; } = CreateDefaultOptions();

    public static JsonSerializerOptions CreateOptionsWith(params JsonConverter[] converters)
    {
        if (converters == null || converters.Length == 0)
        {
            return DefaultOptions;
        }

        var options = new JsonSerializerOptions(DefaultOptions);
        foreach (var converter in converters)
        {
            options.Converters.Add(converter);
        }

        return options;
    }

    public static JsonSerializerOptions CreateIndentedOptions()
    {
        var options = new JsonSerializerOptions(DefaultOptions)
        {
            WriteIndented = true
        };
        return options;
    }

    public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(json, options ?? DefaultOptions);
    }

    public static T? Deserialize<T>(string json, params JsonConverter[] converters)
    {
        return Deserialize<T>(json, CreateOptionsWith(converters));
    }

    public static string Serialize<T>(T value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, options ?? DefaultOptions);
    }

    private static JsonSerializerOptions CreateDefaultOptions()
    {
        var options = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        // Use factories that can handle both nullable and non-nullable types
        options.Converters.Add(new BooleanConverterFactory());
        options.Converters.Add(new DMYConverterFactory());
        options.Converters.Add(new YMDConverterFactory());
        options.Converters.Add(new YMDHISConverterFactory());
        options.Converters.Add(new ErrorIdConverterFactory());
        options.Converters.Add(new CountryOptionConverter());
        options.Converters.Add(new JsonStringEnumConverter());
        options.Converters.Add(new DecimalConverterFactory());

        return options;
    }
}

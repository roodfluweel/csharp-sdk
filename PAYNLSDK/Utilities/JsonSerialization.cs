using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;

namespace PayNLSdk.Utilities;

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

        options.Converters.Add(new BooleanConverter());
        options.Converters.Add(new DMYConverter());
        options.Converters.Add(new YMDConverter());
        options.Converters.Add(new YMDHISConverter());
        options.Converters.Add(new ErrorIdConverter());
        options.Converters.Add(new CountryOptionConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        return options;
    }
}

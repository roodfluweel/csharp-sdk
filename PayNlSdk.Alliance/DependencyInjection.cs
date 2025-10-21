using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PayNlSdk;

/// <summary>
/// Dependency injection helpers for the Alliance extensions.
/// </summary>
public static class AllianceDependencyInjectionExtensions
{
    /// <summary>
    /// Register the Alliance client and associated abstractions.
    /// </summary>
    public static IServiceCollection AddPayNlAlliance(this IServiceCollection services)
    {
        services.TryAddScoped<IAlliance, Alliance>();
        return services;
    }
}

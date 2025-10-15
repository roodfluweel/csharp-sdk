using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PayNLSdk;
/// <summary>
/// Extension services for Pay.nl SDK
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Register Pay. services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPayNl(this IServiceCollection services)
    {
        // Register your services here
        services.TryAddScoped<ITransaction, Transaction>();
        services.TryAddScoped<IMerchant, Merchant>();
        services.TryAddScoped<IService, Service>();
        services.TryAddScoped<IAlliance, Alliance>();
        services.TryAddScoped<IStatistics, Statistics>();
        services.TryAddScoped<ILanguage, Language>();
        return services;
    }
}

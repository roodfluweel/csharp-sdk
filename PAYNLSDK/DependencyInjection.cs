using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PayNLSdk.Api;
using PayNLSdk.Net;

namespace PayNLSdk;
/// <summary>
/// Extension services for Pay.nl SDK
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Register Pay. services with an optional fixed configuration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="payNlConfiguration">A fixed configuration that can be used to pass your configuration.</param>
    /// <returns></returns>
    public static IServiceCollection AddPayNl(this IServiceCollection services, IPayNlConfiguration? payNlConfiguration = null)
    {
        RegisterCommonServices(services);

        if (payNlConfiguration != null)
        {
            services.TryAddScoped<IClient>(provider => new ApiTokenClient(payNlConfiguration));
        }

        return services;
    }

    /// <summary>
    /// Register Pay. services and provide a factory to resolve the configuration per-scope.
    /// Useful for multi-tenant scenarios where configuration depends on the current request/scope.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configurationFactory">Factory to resolve IPayNlConfiguration using the current IServiceProvider.</param>
    /// <returns></returns>
    public static IServiceCollection AddPayNl(this IServiceCollection services, Func<IServiceProvider, IPayNlConfiguration> configurationFactory)
    {
        if (configurationFactory == null) throw new ArgumentNullException(nameof(configurationFactory));

        RegisterCommonServices(services);

        services.TryAddScoped<IClient>(provider =>
        {
            var cfg = configurationFactory(provider);
            if (cfg == null) throw new InvalidOperationException("Configuration factory returned null");
            return new ApiTokenClient(cfg);
        });

        return services;
    }

    /// <summary>
    /// Register Pay. services and provide a custom client factory.
    /// This allows full control over how IClient is created per-scope.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="clientFactory">Factory to resolve IClient using the current IServiceProvider.</param>
    /// <returns></returns>
    public static IServiceCollection AddPayNl(this IServiceCollection services, Func<IServiceProvider, IClient> clientFactory)
    {
        if (clientFactory == null) throw new ArgumentNullException(nameof(clientFactory));

        RegisterCommonServices(services);

        services.TryAddScoped<IClient>(clientFactory);

        return services;
    }

    private static void RegisterCommonServices(IServiceCollection services)
    {
        // Register your services here
        services.TryAddScoped<ITransaction, Transaction>();
        services.TryAddScoped<IMerchant, Merchant>();
        services.TryAddScoped<IService, Service>();
        services.TryAddScoped<IAlliance, Alliance>();
        services.TryAddScoped<IStatistics, Statistics>();
        services.TryAddScoped<ILanguage, Language>();
    }
}

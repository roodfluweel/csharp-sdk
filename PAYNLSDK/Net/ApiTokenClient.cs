using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PayNlSdk.Api;
using PayNlSdk.Net.ProxyConfigurationInjector;
using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Net;

/// <inheritdoc />
/// <summary>
/// A client which can be constructed with an apiToken and a serviceId
/// </summary>
/// <seealso cref="T:PayNlSdk.Net.Client" />
[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "It can be used by other applications")]
public class ApiTokenClient : Client
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiTokenClient"/> class.
    /// </summary>
    /// <param name="serviceId">The service identifier.</param>
    /// <param name="apiToken">The API token.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="proxyConfigurationInjector">The proxy configuration injector.</param>
    /// <inheritdoc />
    public ApiTokenClient(string serviceId, string apiToken, ILogger<Client>? logger = null, IProxyConfigurationInjector? proxyConfigurationInjector = null)
        : base(new PayNlConfiguration(serviceId, apiToken), logger ?? NullLogger<Client>.Instance, proxyConfigurationInjector ?? new NoProxyConfigurationInjector())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiTokenClient"/> class.
    /// </summary>
    /// <param name="securityConfiguration">The security configuration.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="proxyConfigurationInjector">The proxy configuration injector.</param>
    /// <inheritdoc />
    public ApiTokenClient(IPayNlConfiguration securityConfiguration, ILogger<Client>? logger = null, IProxyConfigurationInjector? proxyConfigurationInjector = null)
        : base(securityConfiguration, logger ?? NullLogger<Client>.Instance, proxyConfigurationInjector ?? new NoProxyConfigurationInjector())
    {
    }
}

/// <summary>
/// No-op proxy configuration injector for when no proxy is needed
/// </summary>
internal class NoProxyConfigurationInjector : IProxyConfigurationInjector
{
    /// <inheritdoc />
    public System.Net.IWebProxy InjectProxyConfiguration(System.Net.IWebProxy proxy, System.Uri targetUri)
    {
        return proxy;
    }
}

using PayNLSdk.Net.ProxyConfigurationInjector;
using System.Diagnostics.CodeAnalysis;
using PayNLSdk.API;

namespace PayNLSdk.Net
{
    /// <summary>
    /// A client which can be constructed with an apiToken and a serviceId
    /// </summary>
    /// <seealso cref="T:PayNLSdk.Net.Client" />
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "It can be used by other applications")]
    public class ApiTokenClient : Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiTokenClient"/> class.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="apiToken">The API token.</param>
        /// <param name="proxyConfigurationInjector">The proxy configuration injector.</param>
        /// <inheritdoc />
        public ApiTokenClient(string serviceId, string apiToken, IProxyConfigurationInjector proxyConfigurationInjector = null)
            : base(new PayNlConfiguration(serviceId, apiToken), proxyConfigurationInjector)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiTokenClient"/> class.
        /// </summary>
        /// <param name="securityConfiguration">The security configuration.</param>
        /// <param name="proxyConfigurationInjector">The proxy configuration injector.</param>
        /// <inheritdoc />
        public ApiTokenClient(IPayNlConfiguration securityConfiguration, IProxyConfigurationInjector proxyConfigurationInjector = null) : base(securityConfiguration, proxyConfigurationInjector)
        {
        }
    }
}

using System.Net;

namespace PayNLSdk.Net.ProxyConfigurationInjector
{
    public class InjectDefaultCredentialsForProxiedUris: InjectCredentialsForProxiedUris 
    {
        public InjectDefaultCredentialsForProxiedUris(): base (CredentialCache.DefaultCredentials)
        {
        }
    }
}

using System.Net;

namespace PayNlSdk.Net.ProxyConfigurationInjector;

public class InjectDefaultCredentialsForProxiedUris : InjectCredentialsForProxiedUris
{
    public InjectDefaultCredentialsForProxiedUris() : base(CredentialCache.DefaultCredentials)
    {
    }
}

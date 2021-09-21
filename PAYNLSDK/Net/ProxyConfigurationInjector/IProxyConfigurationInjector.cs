using System;
using System.Net;

namespace PayNLSdk.Net.ProxyConfigurationInjector
{
    public interface IProxyConfigurationInjector
    {
        IWebProxy InjectProxyConfiguration(IWebProxy webProxy, Uri uri);
    }
}
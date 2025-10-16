using System;
using System.Net;

namespace PayNlSdk.Net.ProxyConfigurationInjector;

public interface IProxyConfigurationInjector
{
    IWebProxy InjectProxyConfiguration(IWebProxy webProxy, Uri uri);
}

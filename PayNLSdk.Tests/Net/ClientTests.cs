using System;
using System.Collections.Specialized;
using System.Reflection;
using PAYNLSDK.API;
using PAYNLSDK.Net;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Net;

public class ClientTests
{
    [Fact]
    public void ClientVersion_ShouldExposeSdkVersion()
    {
        // Arrange
        var configuration = new PayNlConfiguration("SL-1234-5678", "token");
        var client = new Client(configuration);

        // Act
        var version = client.ClientVersion;

        // Assert
        version.ShouldBe("1.1.0.0");
    }

    [Fact]
    public void UserAgent_ShouldContainVersionAndFrameworkMajor()
    {
        // Arrange
        var configuration = new PayNlConfiguration("SL-1234-5678", "token");
        var client = new Client(configuration);

        // Act
        var userAgent = client.UserAgent;

        // Assert
        userAgent.ShouldBe($"PAYNL/SDK/{client.ClientVersion} DotNet/{Environment.Version.Major}");
    }

    [Fact]
    public void ToQueryString_ShouldIncludeCredentialsAndEncodeValues()
    {
        // Arrange
        var configuration = new PayNlConfiguration("SL-1234-5678", "api token");
        var client = new Client(configuration);
        var request = new ReflectionFriendlyRequest(
            new NameValueCollection { { "custom key", "value with spaces" } },
            requiresApiToken: true,
            requiresServiceId: true);

        // Act
        var query = InvokeToQueryString(client, request);

        // Assert
        query.ShouldBe("custom%20key=value%20with%20spaces&token=api%20token&serviceId=SL-1234-5678");
    }

    [Fact]
    public void ToQueryString_ShouldReturnEmptyWhenNoParameters()
    {
        // Arrange
        var configuration = new PayNlConfiguration("SL-1234-5678", "token");
        var client = new Client(configuration);
        var request = new ReflectionFriendlyRequest(new NameValueCollection());

        // Act
        var query = InvokeToQueryString(client, request);

        // Assert
        query.ShouldBeEmpty();
    }

    private static string InvokeToQueryString(Client client, RequestBase request)
    {
        var toQueryString = typeof(Client).GetMethod("ToQueryString", BindingFlags.Instance | BindingFlags.NonPublic);
        toQueryString.ShouldNotBeNull();
        var result = toQueryString.Invoke(client, new object[] { request });
        result.ShouldNotBeNull();
        return (string)result;
    }

    private sealed class ReflectionFriendlyRequest : RequestBase
    {
        private readonly NameValueCollection _parameters;
        private readonly bool _requiresApiToken;
        private readonly bool _requiresServiceId;

        public ReflectionFriendlyRequest(NameValueCollection parameters, bool requiresApiToken = false, bool requiresServiceId = false)
        {
            _parameters = parameters;
            _requiresApiToken = requiresApiToken;
            _requiresServiceId = requiresServiceId;
        }

        public override bool RequiresApiToken => _requiresApiToken;

        public override bool RequiresServiceId => _requiresServiceId;

        protected override int Version => 1;

        protected override string Controller => nameof(Transaction);

        protected override string Method => "test";

        public override NameValueCollection GetParameters() => _parameters;

        protected override void PrepareAndSetResponse()
        {
        }
    }
}

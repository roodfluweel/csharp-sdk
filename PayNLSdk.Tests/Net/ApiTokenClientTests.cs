using System.Reflection;
using PayNlSdk.Api;
using PayNlSdk.Net;
using Shouldly;
using Xunit;

namespace PayNlSdk.Tests.Net;

public class ApiTokenClientTests
{
    [Fact]
    public void Constructor_WithCredentials_ShouldCreateConfigurationWithValues()
    {
        // Arrange
        const string serviceId = "SL-9876-5432";
        const string apiToken = "token-value";

        // Act
        var client = new ApiTokenClient(serviceId, apiToken);

        // Assert
        var configuration = ReadConfiguration(client);
        configuration.ServiceId.ShouldBe(serviceId);
        configuration.ApiToken.ShouldBe(apiToken);
    }

    [Fact]
    public void Constructor_WithConfiguration_ShouldReuseProvidedInstance()
    {
        // Arrange
        var configuration = new PayNlConfiguration("SL-0000-1111", "abc");

        // Act
        var client = new ApiTokenClient(configuration);

        // Assert
        ReadConfiguration(client).ShouldBeSameAs(configuration);
    }

    private static IPayNlConfiguration ReadConfiguration(Client client)
    {
        var configurationField = typeof(Client).GetField("SecurityConfiguration", BindingFlags.Instance | BindingFlags.NonPublic);
        configurationField.ShouldNotBeNull();
        return (IPayNlConfiguration)configurationField.GetValue(client);
    }
}

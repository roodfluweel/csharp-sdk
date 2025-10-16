using NSubstitute;
using PayNlSdk;
using PayNlSdk.Api;
using PayNlSdk.Net;
using Shouldly;
using Xunit;

using ServiceGetCategoriesRequest = PayNlSdk.Api.Service.GetCategories.Request;

namespace PayNlSdk.Tests;

public class ServiceTests
{
    private readonly IClient _client;
    private readonly Service _sut;

    public ServiceTests()
    {
        _client = Substitute.For<IClient>();
        _sut = new Service(_client);
    }

    [Fact]
    public void GetCategories_ShouldRequestAllCategoriesWhenPaymentOptionMissing()
    {
        // Arrange
        const string rawResponse = """
        [
          {
            "id": "SC-1",
            "name": "Retail"
          }
        ]
        """;
        _client.PerformRequest(Arg.Do<RequestBase>(request =>
        {
            request.ShouldBeOfType<ServiceGetCategoriesRequest>();
            request.RawResponse = rawResponse;
        }));

        // Act
        var response = _sut.GetCategories();

        // Assert
        _client.Received(1).PerformRequest(Arg.Any<ServiceGetCategoriesRequest>());
        response.ShouldNotBeNull();
        response.ServiceCategories.ShouldNotBeNull();
        response.ServiceCategories.Length.ShouldBe(1);
        response.ServiceCategories[0].Id.ShouldBe("SC-1");
        response.ServiceCategories[0].Name.ShouldBe("Retail");
    }

    [Fact]
    public void GetCategories_ShouldForwardPaymentOptionIdToRequest()
    {
        // Arrange
        ServiceGetCategoriesRequest? capturedRequest = null;
        const string rawResponse = """
        [
          {
            "id": "SC-2",
            "name": "Hospitality"
          }
        ]
        """;
        _client.PerformRequest(Arg.Do<RequestBase>(request =>
        {
            capturedRequest = request.ShouldBeOfType<ServiceGetCategoriesRequest>();
            request.RawResponse = rawResponse;
        }));

        // Act
        var response = _sut.GetCategories(paymentOptionId: 42);

        // Assert
        _client.Received(1).PerformRequest(Arg.Any<ServiceGetCategoriesRequest>());
        capturedRequest.ShouldNotBeNull();
        capturedRequest!.PaymentOptionId.ShouldBe(42);
        response.ShouldNotBeNull();
        response.ServiceCategories.ShouldNotBeNull();
        response.ServiceCategories[0].Name.ShouldBe("Hospitality");
    }
}

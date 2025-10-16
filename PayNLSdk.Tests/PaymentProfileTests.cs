using NSubstitute;
using PayNlSdk;
using PayNlSdk.Net;
using PayNlSdk.Api;
using Shouldly;
using Xunit;

using PaymentProfileGetRequest = PayNlSdk.Api.PaymentProfile.Get.Request;
using PaymentProfileGetAllRequest = PayNlSdk.Api.PaymentProfile.GetAll.Request;
using PaymentProfileGetAvailableRequest = PayNlSdk.Api.PaymentProfile.GetAvailable.Request;

namespace PayNlSdk.Tests;

public class PaymentProfileTests
{
    [Fact]
    public void Get_ShouldRequestProfileById()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        PaymentProfileGetRequest? capturedRequest = null;
        const string rawResponse = """
        {
          "id": 1001,
          "name": "AfterPay",
          "parent_id": 0,
          "public": true,
          "payment_method_id": 613,
          "country_id": 528,
          "payment_tariff_id": 1,
          "noah_id": 2
        }
        """;
        client.PerformRequest(Arg.Do<RequestBase>(request =>
        {
            capturedRequest = request.ShouldBeOfType<PaymentProfileGetRequest>();
            request.RawResponse = rawResponse;
        }));
        var sut = new PaymentProfile(client);

        // Act
        var response = sut.Get(1001);

        // Assert
        client.Received(1).PerformRequest(Arg.Any<PaymentProfileGetRequest>());
        capturedRequest.ShouldNotBeNull();
        capturedRequest!.PaymentProfileId.ShouldBe(1001);
        response.ShouldNotBeNull();
        response.PaymentProfile.ShouldNotBeNull();
        response.PaymentProfile.Id.ShouldBe(1001);
        response.PaymentProfile.Name.ShouldBe("AfterPay");
        response.PaymentProfile.Public.ShouldBeTrue();
        response.PaymentProfile.PaymentMethodId.ShouldBe(613);
    }

    [Fact]
    public void GetAll_ShouldReturnProfilesFromResponse()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        const string rawResponse = """
        [
          {
            "id": 1002,
            "name": "Visa",
            "parent_id": 0,
            "public": false,
            "payment_method_id": 706,
            "country_id": 840,
            "payment_tariff_id": 2,
            "noah_id": 1
          }
        ]
        """;
        client.PerformRequest(Arg.Do<RequestBase>(request =>
        {
            request.ShouldBeOfType<PaymentProfileGetAllRequest>();
            request.RawResponse = rawResponse;
        }));
        var sut = new PaymentProfile(client);

        // Act
        var response = sut.GetAll();

        // Assert
        client.Received(1).PerformRequest(Arg.Any<PaymentProfileGetAllRequest>());
        response.ShouldNotBeNull();
        response.PaymentProfiles.ShouldNotBeNull();
        response.PaymentProfiles.Length.ShouldBe(1);
        response.PaymentProfiles[0].Id.ShouldBe(1002);
        response.PaymentProfiles[0].Name.ShouldBe("Visa");
        response.PaymentProfiles[0].Public.ShouldBeFalse();
    }

    [Fact]
    public void GetAvailable_ShouldPopulateOptionalParametersAndReturnResponse()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        PaymentProfileGetAvailableRequest? capturedRequest = null;
        const string rawResponse = """
        [
          {
            "id": 2001,
            "name": "Giropay",
            "parent_id": 0,
            "public": true,
            "payment_method_id": 712,
            "country_id": 276,
            "payment_tariff_id": 5,
            "noah_id": 4
          }
        ]
        """;
        client.PerformRequest(Arg.Do<RequestBase>(request =>
        {
            capturedRequest = request.ShouldBeOfType<PaymentProfileGetAvailableRequest>();
            request.RawResponse = rawResponse;
        }));
        var sut = new PaymentProfile(client);

        // Act
        var response = sut.GetAvailable(categoryId: 10, programId: 99, paymentMethodId: 712, showNotAllowedOnRegistration: true);

        // Assert
        client.Received(1).PerformRequest(Arg.Any<PaymentProfileGetAvailableRequest>());
        capturedRequest.ShouldNotBeNull();
        capturedRequest!.CategoryId.ShouldBe(10);
        capturedRequest.ProgramId.ShouldBe(99);
        capturedRequest.PaymentMethodId.ShouldBe(712);
        capturedRequest.ShowNotAllowedOnRegistration.ShouldNotBeNull();
        capturedRequest.ShowNotAllowedOnRegistration!.Value.ShouldBeTrue();
        response.ShouldNotBeNull();
        response.PaymentProfiles.ShouldNotBeNull();
        response.PaymentProfiles.Length.ShouldBe(1);
        response.PaymentProfiles[0].Name.ShouldBe("Giropay");
    }
}

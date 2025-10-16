using NSubstitute;
using PayNlSdk;
using PayNlSdk.Enums;
using PayNlSdk.Net;
using PayNlSdk.Api;
using Shouldly;
using Xunit;

using PaymentMethodGetRequest = PayNlSdk.Api.PaymentMethod.Get.Request;
using PaymentMethodGetAllRequest = PayNlSdk.Api.PaymentMethod.GetAll.Request;

namespace PayNlSdk.Tests;

public class PaymentMethodTests
{
    [Fact]
    public void Get_ShouldRequestSpecificPaymentMethodAndReturnResponse()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        PaymentMethodGetRequest? capturedRequest = null;
        const string rawResponse = """
        {
          "id": 10,
          "name": "iDEAL",
          "abbreviation": "IDEAL"
        }
        """;
        client
            .PerformRequest(Arg.Do<RequestBase>(request =>
            {
                capturedRequest = request.ShouldBeOfType<PaymentMethodGetRequest>();
                request.RawResponse = rawResponse;
            }));
        var sut = new PaymentMethod(client);

        // Act
        var response = sut.Get(PaymentMethodId.PayPerTransaction);

        // Assert
        client.Received(1).PerformRequest(Arg.Any<PaymentMethodGetRequest>());
        capturedRequest.ShouldNotBeNull();
        capturedRequest!.PaymentMethodId.ShouldBe(PaymentMethodId.PayPerTransaction);
        response.ShouldNotBeNull();
        response.PaymentMethod.ShouldNotBeNull();
        response.PaymentMethod.Id.ShouldBe(10);
        response.PaymentMethod.Name.ShouldBe("iDEAL");
        response.PaymentMethod.Abbreviation.ShouldBe("IDEAL");
    }

    [Fact]
    public void GetAll_ShouldReturnAllPaymentMethodsFromResponse()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        const string rawResponse = """
        [
          {
            "id": 613,
            "name": "PayPal",
            "abbreviation": "PAYPAL"
          }
        ]
        """;
        client
            .PerformRequest(Arg.Do<RequestBase>(request =>
            {
                request.ShouldBeOfType<PaymentMethodGetAllRequest>();
                request.RawResponse = rawResponse;
            }));
        var sut = new PaymentMethod(client);

        // Act
        var response = sut.GetAll();

        // Assert
        client.Received(1).PerformRequest(Arg.Any<PaymentMethodGetAllRequest>());
        response.ShouldNotBeNull();
        response.PaymentMethods.ShouldNotBeNull();
        response.PaymentMethods.Length.ShouldBe(1);
        response.PaymentMethods[0].Id.ShouldBe(613);
        response.PaymentMethods[0].Name.ShouldBe("PayPal");
        response.PaymentMethods[0].Abbreviation.ShouldBe("PAYPAL");
    }
}

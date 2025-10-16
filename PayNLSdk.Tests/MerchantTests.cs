using System;
using NSubstitute;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Net;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests;

public class MerchantTests
{

    [Fact]
    public void AddClearing_ShouldReturnParsedResponse()
    {
        // Arrange
        var (client, capture) = CreateClientWithCapture(
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "result": "CL-1"
            }
            """);
        var merchant = new Merchant(client);
        var request = new PayNLSdk.API.Merchant.Clearing.Request { Amount = 10, MerchantId = "M-1" };

        // Act
        var response = merchant.AddClearing(request);

        // Assert
        response.Result.ShouldBe("CL-1");
        capture().ShouldBe(request);
    }

    [Fact]
    public void Create_ShouldReturnParsedResponse()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          },
          "merchantId": "M-2",
          "merchantName": "Test Merchant"
        }
        """;
        var client = CreateClient(rawResponse);
        var merchant = new Merchant(client);
        var request = new PAYNLSDK.API.Merchant.Add.Request();

        // Act
        var response = merchant.Create(request);

        // Assert
        response.MerchantId.ShouldBe("M-2");
        response.MerchantName.ShouldBe("Test Merchant");
    }

    [Fact]
    public void Get_ShouldReturnParsedMerchant()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": "1"
          },
          "merchant": {
            "merchantId": "M-3",
            "name": "Shop"
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var merchant = new Merchant(client);

        // Act
        var response = merchant.Get("M-3");

        // Assert
        response.merchant.merchantId.ShouldBe("M-3");
        response.merchant.name.ShouldBe("Shop");
    }

    private static IClient CreateClient(string rawResponse)
    {
        return CreateClientWithCapture(rawResponse).Client;
    }

    private static (IClient Client, Func<RequestBase?> Capture) CreateClientWithCapture(string rawResponse)
    {
        var client = Substitute.For<IClient>();
        RequestBase? captured = null;
        client.PerformRequest(Arg.Do<RequestBase>(r => captured = r)).Returns(callInfo =>
        {
            callInfo.Arg<RequestBase>().RawResponse = rawResponse;
            return rawResponse;
        });
        return (client, () => captured);
    }
}

using PAYNLSDK;
using Shouldly;
using Xunit;
using NSubstitute;
using PAYNLSDK.Net;
using System;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;

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
            "name": "Shop",
            "cocNumber": "12345678"
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

    [Fact]
    public void Get_ShouldThrowException_WhenMerchantNotFound()
    {
        // Arrange
        var rawResponse = "{\"request\":{\"result\":\"0\",\"errorId\":\"PAY-108\",\"errorMessage\":\"Merchant not found\"}}";
        var client = CreateClient(rawResponse);
        var merchant = new Merchant(client);

        // Act & Assert
        var ex = Should.Throw<PayNlException>(() => merchant.Get("undefined"));
        ex.Message.ShouldBe("Merchant not found");
    }

    [Fact]
    public void Get_ShouldReturnFullMerchantResponse()
    {
        // Arrange
        var rawResponse = "{\"request\":{\"result\":\"1\",\"errorId\":\"\",\"errorMessage\":\"\"},\"merchant\":{\"merchantId\":\"M-6545-4410\",\"name\":\"DAMPEE BVBA\",\"publicName\":\"Roodfluweel\",\"website\":\"https://www.roodfluweel.be\",\"type\":\"28\",\"typeName\":\"BV (Besloten vennootschap)\",\"cocNumber\":\"0881275682\",\"vatNumber\":\"\",\"iban\":\"BE85733034422906\",\"bic\":\"KREDBEBB\",\"bankaccountHolder\":\"DAMPEE BVBA\",\"postalAddress\":{\"street\":\"Borsbeeksebrug\",\"houseNumber\":\"6/64\",\"zipCode\":\"2600\",\"city\":\"Antwerpen\",\"countryCode\":\"BE\",\"countryName\":\"België\"},\"visitAddress\":{\"street\":\"Borsbeeksebrug\",\"houseNumber\":\"6/64\",\"zipCode\":\"2600\",\"city\":\"Antwerpen\",\"countryCode\":\"BE\",\"countryName\":\"België\"},\"tradeNames\":[{\"id\":\"TM-6752-4810\",\"name\":\"DAMPEE BVBA\"},{\"id\":\"TM-4783-3201\",\"name\":\"Roodfluweel\"}],\"contactData\":[{\"type\":\"email\",\"value\":\"info@roodfluweel.be\",\"description\":\"Sales\"},{\"type\":\"email\",\"value\":\"support@roodfluweel.be\",\"description\":\"Ondersteuning voor klanten\"},{\"type\":\"url\",\"value\":\"https://www.roodfluweel.be/contact/\",\"description\":\"Alle vragen van klanten\"}],\"state\":\"ACCEPTED\"}}";
        var client = CreateClient(rawResponse);
        var merchant = new Merchant(client);

        // Act
        var response = merchant.Get("M-6545-4410");

        // Assert
        response.merchant.merchantId.ShouldBe("M-6545-4410");
        response.merchant.name.ShouldBe("DAMPEE BVBA");
        response.merchant.publicName.ShouldBe("Roodfluweel");
        response.merchant.website.ShouldBe("https://www.roodfluweel.be");
        response.merchant.type.ShouldBe("28");
        response.merchant.typeName.ShouldBe("BV (Besloten vennootschap)");
        response.merchant.cocNumber.ShouldBe("0881275682");
        response.merchant.iban.ShouldBe("BE85733034422906");
        response.merchant.bic.ShouldBe("KREDBEBB");
        response.merchant.bankaccountHolder.ShouldBe("DAMPEE BVBA");
        response.merchant.postalAddress.city.ShouldBe("Antwerpen");
        response.merchant.visitAddress.city.ShouldBe("Antwerpen");
        response.merchant.tradeNames.Length.ShouldBe(2);
        response.merchant.contactData.Length.ShouldBe(3);
        response.merchant.state.ShouldBe("ACCEPTED");
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

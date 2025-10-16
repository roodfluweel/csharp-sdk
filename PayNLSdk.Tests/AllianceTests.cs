using NSubstitute;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Net;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests;

public class AllianceTests
{

    [Fact]
    public void GetMerchant_ShouldDeserializeFullResult()
    {
        // Arrange
        var rawResponse = """
{
  "request": {
    "result": true,
    "errorId": null,
    "errorMessage": null
  },
  "merchantId": "M-4",
  "merchantName": "Alliance Merchant",
  "services": []
}
""";
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);
        var request = new PAYNLSDK.API.Alliance.GetMerchant.Request { MerchantId = "M-4" };

        // Act
        var result = alliance.GetMerchant(request);

        // Assert
        result.merchantId.ShouldBe("M-4");
        result.merchantName.ShouldBe("Alliance Merchant");
        result.services.ShouldBeEmpty();
    }

    [Fact]
    public void AddMerchant_ShouldReturnDeserializedResult()
    {
        // Arrange
        var rawResponse = """
{
  "success": true,
  "merchantId": "M-5",
  "merchantToken": "token",
  "accounts": [
    {
      "accountId": "A-1",
      "email": "mail@example.com"
    }
  ]
}
""";
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.AddMerchant(new PAYNLSDK.API.Alliance.AddMerchant.Request());

        // Assert
        result.Success.ShouldBeTrue();
        result.MerchantId.ShouldBe("M-5");
        result.Accounts.ShouldHaveSingleItem();
        result.Accounts[0].AccountId.ShouldBe("A-1");
    }

    [Fact]
    public void AddService_ShouldReturnServiceIdentifier()
    {
        // Arrange
        var rawResponse = """
{
  "request": {
    "result": true,
    "errorId": null,
    "errorMessage": null
  },
  "serviceId": "SL-1000-2000"
}
""";
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.AddService(new PAYNLSDK.API.Alliance.AddService.Request());

        // Assert
        result.ServiceId.ShouldBe("SL-1000-2000");
    }

    [Fact]
    public void AddInvoice_ShouldReturnReferenceId()
    {
        // Arrange
        var rawResponse = """
{
  "request": {
    "result": true,
    "errorId": null,
    "errorMessage": null
  },
  "referenceId": "INV-1"
}
""";
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.AddInvoice(new PAYNLSDK.API.Alliance.AddInvoice.Request());

        // Assert
        result.ReferenceId.ShouldBe("INV-1");
        result.ToString().ShouldContain("INV-1");
    }

    private static IClient CreateClient(string rawResponse)
    {
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Any<RequestBase>()).Returns(callInfo =>
        {
            callInfo.Arg<RequestBase>().RawResponse = rawResponse;
            return rawResponse;
        });
        return client;
    }
}

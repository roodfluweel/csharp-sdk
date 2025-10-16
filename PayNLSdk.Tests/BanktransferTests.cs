using System;
using NSubstitute;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Net;
using Shouldly;
using Xunit;

using BanktransferAddRequest = PAYNLSDK.API.Banktransfer.Add.Request;

namespace PayNLSdk.Tests;

public class BanktransferTests
{
    [Fact]
    public void Add_WithRequest_ShouldReturnResponseFromRequest()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        var request = new BanktransferAddRequest(12.34m, "Alice", "NL01PAYN0123456789", "PAYNNL2A")
        {
            Description = "Invoice 42"
        };
        const string rawResponse = """
        {
          "refundId": "RF-123",
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        client.PerformRequest(Arg.Do<RequestBase>(performedRequest =>
        {
            performedRequest.ShouldBeSameAs(request);
            performedRequest.RawResponse = rawResponse;
        }));
        var sut = new Banktransfer(client);

        // Act
        var response = sut.Add(request);

        // Assert
        client.Received(1).PerformRequest(request);
        response.ShouldNotBeNull();
        response.RefundId.ShouldBe("RF-123");
    }

    [Fact]
    public void Add_WithPrimitiveParameters_ShouldCreateRequestAndPopulateValues()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        BanktransferAddRequest? capturedRequest = null;
        const string rawResponse = """
        {
          "refundId": "RF-456",
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        client.PerformRequest(Arg.Do<RequestBase>(performedRequest =>
        {
            capturedRequest = performedRequest.ShouldBeOfType<BanktransferAddRequest>();
            performedRequest.RawResponse = rawResponse;
        }));
        var sut = new Banktransfer(client);

        // Act
        var response = sut.Add(2599, "Bob", "NL02BANK0123456789", "BANKNL2A");

        // Assert
        client.Received(1).PerformRequest(Arg.Any<BanktransferAddRequest>());
        capturedRequest.ShouldNotBeNull();
        capturedRequest!.AmountInCents.ShouldBe(2599);
        capturedRequest.BankAccountHolder.ShouldBe("Bob");
        capturedRequest.BankAccountNumber.ShouldBe("NL02BANK0123456789");
        capturedRequest.BankAccountBic.ShouldBe("BANKNL2A");
        response.ShouldNotBeNull();
        response.RefundId.ShouldBe("RF-456");
    }

    [Fact]
    public void Request_GetParameters_ShouldIncludeOptionalFields()
    {
        // Arrange
        var processDate = new DateTime(2024, 05, 19);
        var request = new BanktransferAddRequest(12.34m, "Carol", "NL03TEST0123456789", "TESTNL2A")
        {
            Description = "Invoice 99",
            PromotorId = 42,
            Tool = "affiliate",
            Info = "campaign",
            Object = "OBJ-7",
            Extra1 = "custom-1",
            Extra2 = "custom-2",
            Extra3 = "custom-3",
            Currency = "USD",
            ProcessDate = processDate
        };

        // Act
        var parameters = request.GetParameters();

        // Assert
        parameters["amount"].ShouldBe("1234");
        parameters["bankAccountHolder"].ShouldBe("Carol");
        parameters["bankAccountNumber"].ShouldBe("NL03TEST0123456789");
        parameters["bankAccountBic"].ShouldBe("TESTNL2A");
        parameters["description"].ShouldBe("Invoice 99");
        parameters["promotorId"].ShouldBe("42");
        parameters["tool"].ShouldBe("affiliate");
        parameters["info"].ShouldBe("campaign");
        parameters["object"].ShouldBe("OBJ-7");
        parameters["extra1"].ShouldBe("custom-1");
        parameters["extra2"].ShouldBe("custom-2");
        parameters["extra3"].ShouldBe("custom-3");
        parameters["currency"].ShouldBe("USD");
        parameters["processDate"].ShouldBe(processDate.ToString("yyyy-MM-dd"));
    }
}

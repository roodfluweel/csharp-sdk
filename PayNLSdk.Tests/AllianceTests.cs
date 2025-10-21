using System;
using NSubstitute;
using PayNlSdk.Api;
using PayNlSdk.Net;
using Shouldly;
using Xunit;

namespace PayNlSdk.Tests;

public class AllianceTests
{

    [Fact]
    public void GetMerchant_ShouldDeserializeFullResult()
    {
        // Arrange
        var rawResponse =
            """
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
        var request = new PayNlSdk.Api.Alliance.GetMerchant.Request { MerchantId = "M-4" };

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
        var rawResponse =
            """
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
        var result = alliance.AddMerchant(new PayNlSdk.Api.Alliance.AddMerchant.Request());

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
        var rawResponse =
            """
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
        var result = alliance.AddService(new PayNlSdk.Api.Alliance.AddService.Request());

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
        var result = alliance.AddInvoice(new PayNlSdk.Api.Alliance.AddInvoice.Request(
            merchantId: "M-4",
            serviceId: "SL-1000-2000",
            invoiceId: "INV-1",
            description: "Alliance invoice",
            amountInCents: 1234));

        // Assert
        result.ReferenceId.ShouldBe("INV-1");
        result.ToString().ShouldContain("INV-1");
    }

    [Fact]
    public void AddBankAccount_ShouldReturnIssuerUrl()
    {
        // Arrange
        var rawResponse = """
        {
          "request": { "result": true },
          "issuerUrl": "https://issuer.example"
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.AddBankAccount(new PayNlSdk.Api.Alliance.AddBankAccount.Request
        {
            MerchantId = "M-1234-5678",
            ReturnUrl = "https://return.example"
        });

        // Assert
        result.IssuerUrl.ShouldBe("https://issuer.example");
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void GetMerchants_ShouldProjectNestedResponse()
    {
        // Arrange
        var rawResponse = """
        {
          "merchants": [
            {
              "merchantId": "M-1",
              "merchantName": "Merchant One",
              "contract": { "packageType": "Alliance" },
              "services": [
                { "serviceId": "SL-1", "serviceName": "Shop" }
              ]
            }
          ]
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.GetMerchants(new PayNlSdk.Api.Alliance.GetMerchants.Request());

        // Assert
        result.Merchants.ShouldHaveSingleItem();
        var merchant = result.Merchants[0];
        merchant.MerchantId.ShouldBe("M-1");
        merchant.Services.ShouldHaveSingleItem();
        merchant.Services[0].ServiceId.ShouldBe("SL-1");
    }

    [Fact]
    public void EnablePaymentOption_ShouldExposeSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": { "result": true }
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.EnablePaymentOption(new PayNlSdk.Api.Alliance.EnablePaymentOption.Request
        {
            ServiceId = "SL-1234-5678",
            PaymentProfileId = 10
        });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void GetAvailablePaymentOptions_ShouldDeserializeCollection()
    {
        // Arrange
        var rawResponse = """
        {
          "paymentOptions": [
            {
              "id": 1,
              "paymentOptionId": 10,
              "paymentProfileId": 100,
              "name": "iDEAL",
              "state": "available",
              "settings": {
                "merchantId": { "required": true }
              }
            }
          ]
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.GetAvailablePaymentOptions(new PayNlSdk.Api.Alliance.GetAvailablePaymentOptions.Request
        {
            ServiceId = "SL-1234-5678"
        });

        // Assert
        result.PaymentOptions.ShouldHaveSingleItem();
        var option = result.PaymentOptions[0];
        option.Name.ShouldBe("iDEAL");
        option.Settings.ShouldNotBeNull();
    }

    [Fact]
    public void UploadDocument_ShouldExposeResultFlag()
    {
        // Arrange
        var rawResponse = """
        {
          "result": true,
          "errorId": null,
          "errorMessage": null
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.UploadDocument(new PayNlSdk.Api.Alliance.Document.Add.Request
        {
            DocumentId = "DOC-1",
            FileName = "file.pdf",
            Contents = { Convert.ToBase64String(new byte[] { 1, 2, 3 }) }
        });

        // Assert
        result.Result.ShouldBeTrue();
    }

    [Fact]
    public void GetStatistics_ShouldAggregateMetrics()
    {
        // Arrange
        var rawResponse = """
        {
          "arrStatsData": [
            {
              "Id": "M-1",
              "Label": "Merchant One",
              "Data": [
                {
                  "Id": "10",
                  "Label": "iDEAL",
                  "Data": [
                    { "Data": { "num": "2", "org_tot": "500.25" } },
                    { "Data": { "num": 3, "org_tot": 100.75 } }
                  ]
                }
              ]
            }
          ]
        }
        """;
        var alliance = new Alliance(CreateClient(rawResponse));

        // Act
        var result = alliance.GetStatistics(new PayNlSdk.Api.Alliance.Statistics.Request
        {
            StartDate = new DateTime(2024, 1, 1),
            EndDate = new DateTime(2024, 1, 31)
        });

        // Assert
        result.Merchants.ShouldHaveSingleItem();
        var merchant = result.Merchants[0];
        merchant.Totals.Transactions.ShouldBe(5m);
        merchant.Totals.Turnover.ShouldBe(601.0m);
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

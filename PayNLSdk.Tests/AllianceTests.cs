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
        var result = alliance.AddInvoice(new PAYNLSDK.API.Alliance.AddInvoice.Request(
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
    public void GetMerchants_ShouldReturnListOfMerchants()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          },
          "merchants": [
            {
              "merchantId": "M-1",
              "merchantName": "Merchant One",
              "state": "accepted"
            },
            {
              "merchantId": "M-2",
              "merchantName": "Merchant Two",
              "state": "new"
            }
          ]
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.GetMerchants(new PAYNLSDK.API.Alliance.GetMerchants.Request());

        // Assert
        result.Merchants.Count.ShouldBe(2);
        result.Merchants[0].MerchantId.ShouldBe("M-1");
        result.Merchants[0].MerchantName.ShouldBe("Merchant One");
        result.Merchants[0].State.ShouldBe("accepted");
    }

    [Fact]
    public void Suspend_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.Suspend(new PAYNLSDK.API.Alliance.Suspend.Request { MerchantId = "M-4" });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void Unsuspend_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.Unsuspend(new PAYNLSDK.API.Alliance.Unsuspend.Request { MerchantId = "M-4" });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void SetPackage_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.SetPackage(new PAYNLSDK.API.Alliance.SetPackage.Request 
        { 
            MerchantId = "M-4", 
            Package = "AlliancePlus" 
        });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void MarkReady_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.MarkReady(new PAYNLSDK.API.Alliance.MarkReady.Request { MerchantId = "M-4" });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void AddClearing_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.AddClearing(new PAYNLSDK.API.Alliance.AddClearing.Request 
        { 
            Amount = 1000,
            MerchantId = "M-4" 
        });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void AddBankAccount_ShouldReturnIssuerUrl()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          },
          "issuerUrl": "https://example.com/ideal"
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.AddBankAccount(new PAYNLSDK.API.Alliance.AddBankAccount.Request 
        { 
            MerchantId = "M-4",
            ReturnUrl = "https://example.com/return"
        });

        // Assert
        result.IssuerUrl.ShouldBe("https://example.com/ideal");
    }

    [Fact]
    public void GetCategories_ShouldReturnListOfCategories()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          },
          "categories": [
            {
              "id": "1",
              "name": "Category 1",
              "description": "Description 1"
            },
            {
              "id": "2",
              "name": "Category 2",
              "description": "Description 2"
            }
          ]
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.GetCategories(new PAYNLSDK.API.Alliance.GetCategories.Request());

        // Assert
        result.Categories.Count.ShouldBe(2);
        result.Categories[0].Id.ShouldBe("1");
        result.Categories[0].Name.ShouldBe("Category 1");
    }

    [Fact]
    public void GetAvailablePaymentOptions_ShouldReturnListOfOptions()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          },
          "paymentOptions": [
            {
              "id": "10",
              "name": "iDEAL",
              "enabled": true
            },
            {
              "id": "436",
              "name": "Bancontact",
              "enabled": false
            }
          ]
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.GetAvailablePaymentOptions(
            new PAYNLSDK.API.Alliance.GetAvailablePaymentOptions.Request { ServiceId = "SL-1000-2000" });

        // Assert
        result.PaymentOptions.Count.ShouldBe(2);
        result.PaymentOptions[0].Id.ShouldBe("10");
        result.PaymentOptions[0].Name.ShouldBe("iDEAL");
        result.PaymentOptions[0].Enabled.ShouldBeTrue();
    }

    [Fact]
    public void EnablePaymentOption_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.EnablePaymentOption(new PAYNLSDK.API.Alliance.EnablePaymentOption.Request 
        { 
            ServiceId = "SL-1000-2000",
            PaymentProfileId = "10"
        });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void DisablePaymentOption_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "request": {
            "result": true,
            "errorId": null,
            "errorMessage": null
          }
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);

        // Act
        var result = alliance.DisablePaymentOption(new PAYNLSDK.API.Alliance.DisablePaymentOption.Request 
        { 
            ServiceId = "SL-1000-2000",
            PaymentProfileId = "10"
        });

        // Assert
        result.Success.ShouldBeTrue();
    }

    [Fact]
    public void AddDocument_ShouldReturnSuccess()
    {
        // Arrange
        var rawResponse = """
        {
          "result": true,
          "documentId": "D-1234-5678"
        }
        """;
        var client = CreateClient(rawResponse);
        var alliance = new Alliance(client);
        var request = new PAYNLSDK.API.Alliance.AddDocument.Request 
        { 
            DocumentId = "D-1234-5678",
            Filename = "test.pdf"
        };
        request.AddContent("base64encodedcontent");

        // Act
        var result = alliance.AddDocument(request);

        // Assert
        result.Result.ShouldBeTrue();
        result.DocumentId.ShouldBe("D-1234-5678");
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

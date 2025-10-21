using PayNlSdk.Api.Alliance.GetMerchant;
using PayNlSdk.Api.Alliance.GetMerchants;
using PayNlSdk.Utilities;
using Shouldly;
using GetMerchantRequest = PayNlSdk.Api.Alliance.GetMerchant.Request;
using GetMerchantsRequest = PayNlSdk.Api.Alliance.GetMerchants.Request;

namespace PayNlSdk.Alliance.Tests;

public class GetMerchantRequestTests
{
    [Fact]
    public void GetMerchant_RequestUrl_IsCorrect_And_ResultDeserializes()
    {
        // Arrange
        var request = new GetMerchantRequest { MerchantId = "123" };

        // Url property comes from RequestBase
        request.Url.ShouldBe("v7/Alliance/getMerchant/json");

        var json = """
                   {
                     "request": { "result": true },
                     "merchantId": "123",
                     "merchantName": "Test Merchant",
                     "balance": 2500,
                     "services": [],
                     "documents": [],
                     "accounts": [],
                     "bankaccounts": []
                   }
                   """;

        // Act
        var result = JsonSerialization.Deserialize<GetMerchantResult>(json);

        // Assert
        result.ShouldNotBeNull();
        result.merchantId.ShouldBe("123");
        result.merchantName.ShouldBe("Test Merchant");
        result.BalanceInCents.ShouldBe(2500);
        result.Balance.ShouldBe(25m);
    }

    [Fact]
    public void GetMerchants_RequestUrl_IsCorrect_And_ResultDeserializes()
    {
        // Arrange
        var request = new GetMerchantsRequest();
        request.Url.ShouldBe("v7/Alliance/getMerchants/json");

        var json = """
                    {
                      "request": { "result": true },
                      "merchants": [
                        {
                          "merchantId": "1",
                          "merchantName": "M1",
                          "packageName": "pkg",
                          "contract": { "packageType": "type" },
                          "services": [ { "serviceId": "10", "serviceName": "S1" } ]
                        }
                      ]
                    }
                    """;

        // Act
        var result = JsonSerialization.Deserialize<GetMerchantsResult>(json);

        // Assert
        result.ShouldNotBeNull();
        result.Merchants.ShouldNotBeNull();
        result.Merchants.Count.ShouldBe(1);
        var merchant = result.Merchants[0];
        merchant.MerchantId.ShouldBe("1");
        merchant.MerchantName.ShouldBe("M1");
        merchant.PackageName.ShouldBe("pkg");
        merchant.Contract.ShouldNotBeNull();
        merchant.Contract.PackageType.ShouldBe("type");
        merchant.Services.ShouldNotBeNull();
        merchant.Services.Count.ShouldBe(1);
        merchant.Services[0].ServiceId.ShouldBe("10");
        merchant.Services[0].ServiceName.ShouldBe("S1");
    }
}

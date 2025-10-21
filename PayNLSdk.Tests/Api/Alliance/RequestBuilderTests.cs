using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using AddBankAccountRequest = PayNlSdk.Api.Alliance.AddBankAccount.Request;
using AddInvoiceRequest = PayNlSdk.Api.Alliance.AddInvoice.Request;
using AddMerchantAccount = PayNlSdk.Api.Alliance.AddMerchant.Account;
using AddMerchantBankAccount = PayNlSdk.Api.Alliance.AddMerchant.BankAccount;
using AddMerchantRequest = PayNlSdk.Api.Alliance.AddMerchant.Request;
using AddMerchantSettings = PayNlSdk.Api.Alliance.AddMerchant.MerchantSettings;
using AddServicePaymentProfile = PayNlSdk.Api.Alliance.AddService.PaymentProfile;
using AddServiceRequest = PayNlSdk.Api.Alliance.AddService.Request;
using EnablePaymentOptionRequest = PayNlSdk.Api.Alliance.EnablePaymentOption.Request;
using StatisticsRequest = PayNlSdk.Api.Alliance.Statistics.Request;
using Shouldly;
using Xunit;

namespace PayNlSdk.Tests.Api.Alliance;

public class RequestBuilderTests
{
    [Fact]
    public void AddBankAccountRequest_ShouldPopulateParameters()
    {
        var request = new AddBankAccountRequest
        {
            MerchantId = "M-1234-5678",
            ReturnUrl = "https://example.com",
            BankId = 1,
            PaymentOptionId = 10
        };

        NameValueCollection parameters = request.GetParameters();

        parameters["merchantId"].ShouldBe("M-1234-5678");
        parameters["returnUrl"].ShouldBe("https://example.com");
        parameters["bankId"].ShouldBe("1");
        parameters["paymentOptionId"].ShouldBe("10");
    }

    [Fact]
    public void EnablePaymentOptionRequest_ShouldAddSettings()
    {
        var request = new EnablePaymentOptionRequest
        {
            ServiceId = "SL-1234-5678",
            PaymentProfileId = 739
        };
        request.Settings["merchantId"] = "123";
        request.Settings["merchantPassword"] = "secret";

        NameValueCollection parameters = request.GetParameters();

        parameters["serviceId"].ShouldBe("SL-1234-5678");
        parameters["paymentProfileId"].ShouldBe("739");
        parameters["settings[merchantId]"].ShouldBe("123");
        parameters["settings[merchantPassword]"].ShouldBe("secret");
    }

    [Fact]
    public void StatisticsRequest_ShouldRequireDates()
    {
        var request = new StatisticsRequest();
        Should.Throw<ValidationException>(() => request.GetParameters());

        request.StartDate = new DateTime(2024, 1, 1);
        Should.Throw<ValidationException>(() => request.GetParameters());

        request.EndDate = new DateTime(2024, 1, 31);
        NameValueCollection parameters = request.GetParameters();

        parameters["startDate"].ShouldBe("2024-01-01");
        parameters["endDate"].ShouldBe("2024-01-31");
        parameters["groupBy[0]"].ShouldBe("company_id");
        parameters["groupBy[1]"].ShouldBe("payment_profile_id");
    }

    [Fact]
    public void AddMerchantRequest_ShouldMatchPhpParameterStructure()
    {
        var request = new AddMerchantRequest
        {
            FullName = "Merchant BV",
            Coc = "12345678",
            Vat = "NL123",
            Street = "Mainstreet",
            HouseNumber = "10",
            PostalCode = "1234AB",
            City = "Amsterdam",
            CountryCode = "NL",
            ContactEmail = "info@example.com"
        };

        request.Accounts.Add(new AddMerchantAccount
        {
            Email = "ubo@example.com",
            FirstName = "John",
            LastName = "Doe",
            Gender = AddMerchantAccount.GenderEnum.M,
            AuthorizedToSign = AddMerchantAccount.AuthorizedToSignEnum.AuthorizedIndependently,
            UltimateBeneficialOwner = true,
            UboPercentage = 100,
            UseCompanyAuth = true,
            HasAccess = true,
            Language = "NL"
        });

        request.BankAccount = new AddMerchantBankAccount
        {
            BankAccountOwner = "Merchant BV",
            BankAccountNumber = "NL00BANK0123456789",
            BankAccountBic = "BANKNL2A"
        };

        request.MerchantSettings = new AddMerchantSettings
        {
            Package = "Alliance",
            SendEmail = "1",
            SettleBalance = true,
            ReferralProfileId = "RP-1",
            ClearingInterval = "month"
        };

        NameValueCollection parameters = request.GetParameters();

        parameters["accounts[0][authorizedToSign]"].ShouldBe("1");
        parameters["accounts[0][ubo]"].ShouldBe("1");
        parameters["bankAccount[bankAccountOwner]"].ShouldBe("Merchant BV");
        parameters["settings[packageName]"].ShouldBe("Alliance");
        parameters["settings[settleBalance]"].ShouldBe("1");
    }

    [Fact]
    public void AddServiceRequest_ShouldIncludeExtendedOptions()
    {
        var request = new AddServiceRequest
        {
            MerchantId = "M-1000",
            Name = "Webshop",
            Description = "Online store",
            CategoryId = "3945",
            Publication = "https://example.com"
        };

        request.PublicationUrls.Add("https://example.com/about");

        var profile = new AddServicePaymentProfile { Id = 600 };
        profile.AddSetting("merchantId", "123");
        request.PaymentOptions.Add(profile);

        request.ExchangeParameters["url"] = "https://hooks.example";
        request.AlwaysSendExchange = true;
        request.PluginVersionId = "PV-0000-0000";
        request.ContactPhone = "+31101234567";

        NameValueCollection parameters = request.GetParameters();

        parameters["paymentOptions[0][id]"].ShouldBe("600");
        parameters["paymentOptions[0][settings][merchantId]"].ShouldBe("123");
        parameters["publicationUrls[0]"].ShouldBe("https://example.com/about");
        parameters["exchange[url]"].ShouldBe("https://hooks.example");
        parameters["exchange[alwaysSendExchange]"].ShouldBe("1");
        parameters["pluginVersionId"].ShouldBe("PV-0000-0000");
        parameters["contactPhone"].ShouldBe("+31101234567");
    }

    [Fact]
    public void AddInvoiceRequest_ShouldEmitOptionalParameters()
    {
        var request = new AddInvoiceRequest(
            merchantId: "M-400",
            serviceId: "SL-1000-2000",
            invoiceId: "INV-42",
            description: "Alliance invoice",
            amountInCents: 2500)
        {
            InvoiceUrl = "https://example.com/invoice.pdf",
            MakeYesterday = true,
            Extra1 = "foo",
            Extra2 = "bar",
            Extra3 = "baz",
            MerchantServiceId = "SL-OTHER"
        };

        NameValueCollection parameters = request.GetParameters();

        parameters["makeYesterday"].ShouldBe("1");
        parameters["extra3"].ShouldBe("baz");
        parameters["merchantServiceId"].ShouldBe("SL-OTHER");
        parameters["amount"].ShouldBe("2500");
    }
}

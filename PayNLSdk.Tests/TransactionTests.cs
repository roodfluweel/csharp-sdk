using NSubstitute;
using NSubstitute.ExceptionExtensions;
using PayNlSdk.Api;
using PayNlSdk.Api.Transaction;
using PayNlSdk.Api.Transaction.Start;
using PayNlSdk.Enums;
using PayNlSdk.Exceptions;
using PayNlSdk.Net;
using PayNlSdk.Objects;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xunit;
using TransactionApproveRequest = PayNlSdk.Api.Transaction.Approve.Request;
using TransactionDeclineRequest = PayNlSdk.Api.Transaction.Decline.Request;
using TransactionGetServiceRequest = PayNlSdk.Api.Transaction.GetService.Request;
using TransactionRefundRequest = PayNlSdk.Api.Transaction.Refund.Request;
using TransactionStartRequest = PayNlSdk.Api.Transaction.Start.Request;

namespace PayNlSdk.Tests;

public class TransactionTests
{

    [Fact]
    public void IsPaid_ShouldReturnTrueWhenStateIsPaid()
    {
        // Arrange
        var client = CreateClient(BuildInfoResponse(PaymentStatus.PAID));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsPaid("TRANS-1");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsCancelled_ShouldReturnTrueWhenStateIsCancelled()
    {
        // Arrange
        var client = CreateClient(BuildInfoResponse(PaymentStatus.CANCEL));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsCancelled("TRANS-2");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsCancelled_ShouldReturnFalseWhenRequestThrows()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Any<RequestBase>()).Throws(new PayNlException("network"));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsCancelled("TRANS-3");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsPending_ShouldReturnTrueForPendingState()
    {
        // Arrange
        var client = CreateClient(BuildInfoResponse(PaymentStatus.PENDING_1));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsPending("TRANS-4");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsPending_ShouldReturnTrueWhenStateNameIsPending()
    {
        // Arrange
        var client = CreateClient(BuildInfoResponse(PaymentStatus.OPEN, "PENDING"));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsPending("TRANS-5");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsPending_ShouldReturnFalseWhenExceptionThrown()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Any<RequestBase>()).Throws(new PayNlException("error"));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsPending("TRANS-6");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsVerify_ShouldReturnTrueForVerifyStatus()
    {
        // Arrange
        var client = CreateClient(BuildInfoResponse(PaymentStatus.VERIFY));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsVerify("TRANS-7");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsVerify_ShouldReturnFalseWhenExceptionThrown()
    {
        // Arrange
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Any<RequestBase>()).Throws(new PayNlException("error"));
        var transaction = new Transaction(client);

        // Act
        var result = transaction.IsVerify("TRANS-8");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsRefund_ShouldRecognizeRefundStatuses()
    {
        // Arrange & Act
        var refund = Transaction.IsRefund(PaymentStatus.REFUND);
        var refunding = Transaction.IsRefund(PaymentStatus.REFUNDING);
        var paid = Transaction.IsRefund(PaymentStatus.PAID);

        // Assert
        refund.ShouldBeTrue();
        refunding.ShouldBeTrue();
        paid.ShouldBeFalse();
    }

    [Fact]
    public void IsRefunding_ShouldOnlyReturnTrueForRefundingStatus()
    {
        // Arrange & Act
        var refunding = Transaction.IsRefunding(PaymentStatus.REFUNDING);
        var paid = Transaction.IsRefunding(PaymentStatus.PAID);

        // Assert
        refunding.ShouldBeTrue();
        paid.ShouldBeFalse();
    }

    [Fact]
    public void Info_ShouldReturnDeserializedResponse()
    {
        // Arrange
        var rawResponse = BuildInfoResponse(PaymentStatus.PAID);
        var client = CreateClient(rawResponse);
        var transaction = new Transaction(client);

        // Act
        var response = transaction.Info("TRANS-9");

        // Assert
        response.PaymentDetails.State.ShouldBe(PaymentStatus.PAID);
    }

    [Fact]
    public void GetService_ShouldPassPaymentMethodAndReturnResponse()
    {
        // Arrange
        var client = CreateClientWithCapture(BuildGetServiceResponse(), out var capturedRequestAccessor);
        var transaction = new Transaction(client);

        // Act
        var response = transaction.GetService(PaymentMethodId.PayPerTransaction);

        // Assert
        response.Service.ShouldNotBeNull();
        var capturedRequest = capturedRequestAccessor();
        capturedRequest.ShouldBeOfType<TransactionGetServiceRequest>();
        ((TransactionGetServiceRequest)capturedRequest!).PaymentMethodId.ShouldBe(PaymentMethodId.PayPerTransaction);
    }

    [Fact]
    public void GetService_WithoutPaymentMethod_ShouldReuseOverload()
    {
        // Arrange
        var client = CreateClient(BuildGetServiceResponse());
        var transaction = new Transaction(client);

        // Act
        var response = transaction.GetService();

        // Assert
        response.CountryOptions.ShouldNotBeNull();
    }

    [Fact]
    public void Refund_ShouldPopulateRequestAndReturnResponse()
    {
        // Arrange
        var client = CreateClientWithCapture(BuildRefundResponse("RF-1"), out var capturedRequestAccessor);
        var transaction = new Transaction(client);
        var processDate = new DateTime(2024, 6, 15);

        // Act
        var response = transaction.Refund("TRANS-10", "Description", 12.34m, processDate);

        // Assert
        response.RefundId.ShouldBe("RF-1");
        var refundRequest = capturedRequestAccessor().ShouldBeOfType<TransactionRefundRequest>();
        refundRequest.TransactionId.ShouldBe("TRANS-10");
        refundRequest.Description.ShouldBe("Description");
        refundRequest.Amount.ShouldBe(12.34m);
        refundRequest.ProcessDate.ShouldBe(processDate);

        NameValueCollection parameters = refundRequest.GetParameters();
        parameters["transactionId"].ShouldBe("TRANS-10");
        parameters["amount"].ShouldBe(((int)Math.Floor(12.34m * 100)).ToString());
        parameters["description"].ShouldBe("Description");
        parameters["processDate"].ShouldBe(processDate.ToString("dd-MM-yyyy"));
    }

    [Fact]
    public void Approve_ShouldSendRequestAndReturnMessage()
    {
        // Arrange
        var client = CreateClientWithCapture(BuildApproveResponse("approved"), out var capturedRequestAccessor);
        var transaction = new Transaction(client);

        // Act
        var response = transaction.Approve("TRANS-11");

        // Assert
        response.Message.ShouldBe("approved");
        var approveRequest = capturedRequestAccessor().ShouldBeOfType<TransactionApproveRequest>();
        approveRequest.TransactionId.ShouldBe("TRANS-11");
        approveRequest.GetParameters()["orderId"].ShouldBe("TRANS-11");
    }

    [Fact]
    public void Decline_ShouldSendRequestAndReturnMessage()
    {
        // Arrange
        var client = CreateClientWithCapture(BuildDeclineResponse("declined"), out var capturedRequestAccessor);
        var transaction = new Transaction(client);

        // Act
        var response = transaction.Decline("TRANS-12");

        // Assert
        response.Message.ShouldBe("declined");
        var declineRequest = capturedRequestAccessor().ShouldBeOfType<TransactionDeclineRequest>();
        declineRequest.TransactionId.ShouldBe("TRANS-12");
        declineRequest.GetParameters()["orderId"].ShouldBe("TRANS-12");
    }

    [Fact]
    public void CreateTransactionRequest_ShouldConvertAmountAndPopulateFields()
    {
        // Arrange & Act
        var request = Transaction.CreateTransactionRequest(10.015m, "127.0.0.1", "https://return", 10, 1, true, "merchant", "M-1234-5678");

        // Assert
        request.Amount.ShouldBe((int)Math.Round(10.015m * 100));
        request.IPAddress.ShouldBe("127.0.0.1");
        request.ReturnUrl.ShouldBe("https://return");
        request.PaymentOptionId.ShouldBe(10);
        request.PaymentOptionSubId.ShouldBe(1);
        request.TestMode.ShouldBeTrue();
        request.TransferType.ShouldBe("merchant");
        request.TransferValue.ShouldBe("M-1234-5678");
    }

    [Fact]
    public void Start_ShouldPerformRequestAndReturnResponse()
    {
        // Arrange
        var client = CreateClient(BuildStartResponse());
        var transaction = new Transaction(client);
        var request = new TransactionStartRequest
        {
            Amount = 100,
            IPAddress = "127.0.0.1",
            ReturnUrl = "https://return"
        };

        // Act
        var response = transaction.Start(request);

        // Assert
        response.Transaction.TransactionId.ShouldBe("TRANS-13");
        response.Transaction.PaymentReference.ShouldBe("REF");
    }

    [Fact]
    public void StartRequest_GetParameters_ShouldIncludeNestedStructures()
    {
        // Arrange
        var request = new TransactionStartRequest
        {
            Amount = 1234,
            IPAddress = "127.0.0.1",
            ReturnUrl = "https://return",
            PaymentOptionId = 10,
            PaymentOptionSubId = 20,
            TransferType = "merchant",
            TransferValue = "M-1234",
            TransactionData = new TransactionData
            {
                Currency = "USD",
                CostsVat = 21,
                OrderExchangeUrl = "https://exchange",
                OrderNumber = "ORD-1",
                Description = "Test order",
                EnduserId = 55,
                ExpireDate = new DateTime(2024, 6, 1, 12, 30, 0)
            },
            StatsData = new StatsDetails
            {
                PromotorId = 7,
                Info = "newsletter",
                Tool = "widget",
                Extra1 = "alpha",
                Extra2 = "beta",
                Extra3 = "gamma"
            },
            Enduser = new EndUser
            {
                Language = "NL",
                Initials = "JD",
                Lastname = "Doe",
                Gender = Gender.Male,
                BirthDate = new DateTime(1985, 4, 12),
                PhoneNumber = "+310123456789",
                EmailAddress = "jd@example.test",
                CustomerReference = "CUST-77",
                Address = new Address
                {
                    StreetName = "Main Street",
                    StreetNumber = "10",
                    StreetNumberExtension = "A",
                    ZipCode = "1234AB",
                    City = "Amsterdam",
                    CountryCode = "NL"
                },
                InvoiceAddress = new Address
                {
                    Initials = "JD",
                    LastName = "Doe",
                    Gender = Gender.Male,
                    StreetName = "Invoice Street",
                    StreetNumber = "20",
                    StreetNumberExtension = "B",
                    ZipCode = "4321BA",
                    City = "Rotterdam",
                    CountryCode = "NL"
                },
                Company = new Company
                {
                    Name = "Acme BV",
                    CocNumber = "12345678",
                    VatNumber = "NL999999999B01",
                    CountryCode = "NL"
                }
            },
            SalesData = new SalesData
            {
                InvoiceDate = new DateTime(2024, 5, 1),
                DeliveryDate = new DateTime(2024, 5, 2),
                OrderData = new List<OrderData>
                {
                    new("SKU-1", "Widget", 2500, TaxClass.High, 2, ProductType.ARTICLE)
                }
            },
            TestMode = true
        };

        // Act
        var parameters = request.GetParameters();

        // Assert
        parameters["amount"].ShouldBe("1234");
        parameters["ipAddress"].ShouldBe("127.0.0.1");
        parameters["finishUrl"].ShouldBe("https://return");
        parameters["paymentOptionId"].ShouldBe("10");
        parameters["paymentOptionSubId"].ShouldBe("20");
        parameters["transferType"].ShouldBe("merchant");
        parameters["transferValue"].ShouldBe("M-1234");
        parameters["transaction[currency]"].ShouldBe("USD");
        parameters["transaction[costsVat]"].ShouldBe("21");
        parameters["transaction[orderExchangeUrl]"].ShouldBe("https://exchange");
        parameters["transaction[orderNumber]"].ShouldBe("ORD-1");
        parameters["transaction[description]"].ShouldBe("Test order");
        parameters["transaction[enduserId]"].ShouldBe("55");
        parameters["transaction[expireDate]"].ShouldBe("01-06-2024 12:30:00");
        parameters["statsData[promotorId]"].ShouldBe("7");
        parameters["statsData[info]"].ShouldBe("newsletter");
        parameters["statsData[tool]"].ShouldBe("widget");
        parameters["statsData[extra1]"].ShouldBe("alpha");
        parameters["statsData[extra2]"].ShouldBe("beta");
        parameters["statsData[extra3]"].ShouldBe("gamma");
        parameters["enduser[language]"].ShouldBe("NL");
        parameters["enduser[initials]"].ShouldBe("JD");
        parameters["enduser[lastName]"].ShouldBe("Doe");
        parameters["enduser[gender]"].ShouldBe("m");
        parameters["enduser[dob]"].ShouldBe("12-04-1985");
        parameters["enduser[phoneNumber]"].ShouldBe("+310123456789");
        parameters["enduser[emailAddress]"].ShouldBe("jd@example.test");
        parameters["enduser[customerReference]"].ShouldBe("CUST-77");
        parameters["enduser[address][streetName]"].ShouldBe("Main Street");
        parameters["enduser[address][streetNumber]"].ShouldBe("10");
        parameters["enduser[address][streetNumberExtension]"].ShouldBe("A");
        parameters["enduser[address][zipCode]"].ShouldBe("1234AB");
        parameters["enduser[address][city]"].ShouldBe("Amsterdam");
        parameters["enduser[address][countryCode]"].ShouldBe("NL");
        parameters["enduser[invoiceAddress][initials]"].ShouldBe("JD");
        parameters["enduser[invoiceAddress][lastName]"].ShouldBe("Doe");
        parameters["enduser[invoiceAddress][gender]"].ShouldBe("m");
        parameters["enduser[invoiceAddress][streetName]"].ShouldBe("Invoice Street");
        parameters["enduser[invoiceAddress][streetNumber]"].ShouldBe("20");
        parameters["enduser[invoiceAddress][streetNumberExtension]"].ShouldBe("B");
        parameters["enduser[invoiceAddress][zipCode]"].ShouldBe("4321BA");
        parameters["enduser[invoiceAddress][city]"].ShouldBe("Rotterdam");
        parameters["enduser[invoiceAddress][countryCode]"].ShouldBe("NL");
        parameters["enduser[company][name]"].ShouldBe("Acme BV");
        parameters["enduser[company][cocNumber]"].ShouldBe("12345678");
        parameters["enduser[company][vatNumber]"].ShouldBe("NL999999999B01");
        parameters["enduser[company][countryCode]"].ShouldBe("NL");
        parameters["saleData[deliveryDate]"].ShouldBe("02-05-2024");
        parameters["saleData[invoiceDate]"].ShouldBe("01-05-2024");
        parameters["saleData[orderData][0][productId]"].ShouldBe("SKU-1");
        parameters["saleData[orderData][0][description]"].ShouldBe("Widget");
        parameters["saleData[orderData][0][price]"].ShouldBe("2500");
        parameters["saleData[orderData][0][quantity]"].ShouldBe("2");
        parameters["saleData[orderData][0][vatCode]"].ShouldBe("H");
        parameters["saleData[orderData][0][productType]"].ShouldBe("ARTICLE");
        parameters["testMode"].ShouldBe("1");
    }

    [Fact]
    public void StartRequest_GetParameters_ShouldThrowForInvalidTransfer()
    {
        // Arrange
        var request = new TransactionStartRequest
        {
            Amount = 100,
            IPAddress = "127.0.0.1",
            ReturnUrl = "https://return",
            TransferType = "invalid",
            TransferValue = "value"
        };

        // Act & Assert
        Should.Throw<Exception>(() => request.GetParameters())
            .Message.ShouldContain("TransferValue cannot be set");
    }

    private static IClient CreateClient(string rawResponse)
    {
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Any<RequestBase>()).Returns(callInfo =>
        {
            var request = callInfo.Arg<RequestBase>();
            request.RawResponse = rawResponse;
            return rawResponse;
        });
        return client;
    }

    private static IClient CreateClientWithCapture(string rawResponse, out Func<RequestBase?> capturedRequestAccessor)
    {
        RequestBase? capturedRequest = null;
        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Do<RequestBase>(r => capturedRequest = r)).Returns(callInfo =>
        {
            var request = callInfo.Arg<RequestBase>();
            request.RawResponse = rawResponse;
            return rawResponse;
        });
        capturedRequestAccessor = () => capturedRequest;
        return client;
    }

    private static string BuildInfoResponse(PaymentStatus status, string stateName = null)
    {
        stateName ??= status.ToString();
        return
            $$"""
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "paymentDetails": {
                "state": {{(int)status}},
                "stateName": "{{stateName}}"
              }
            }
            """;
    }

    private static string BuildGetServiceResponse()
    {
        return
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "merchant": {},
              "service": {},
              "countryOptionList": {}
            }
            """;
    }

    private static string BuildRefundResponse(string refundId)
    {
        return
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "refundId": "{{refundId}}"
            }
            """.Replace("{{refundId}}", refundId);
    }

    private static string BuildApproveResponse(string message)
    {
        return
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "message": "{{message}}"
            }
            """.Replace("{{message}}", message);
    }

    private static string BuildDeclineResponse(string message)
    {
        return
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "message": "{{message}}"
            }
            """.Replace("{{message}}", message);
    }

    private static string BuildStartResponse()
    {
        return
            """
            {
              "request": {
                "result": true,
                "errorId": null,
                "errorMessage": null
              },
              "transaction": {
                "transactionId": "TRANS-13",
                "paymentReference": "REF"
              }
            }
            """;
    }
}

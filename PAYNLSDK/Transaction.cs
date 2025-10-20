using PayNlSdk.Api.Transaction.Info;
using PayNlSdk.Enums;
using PayNlSdk.Exceptions;
using PayNlSdk.Net;
using System;
using Request = PayNlSdk.Api.Transaction.Start.Request;
using Response = PayNlSdk.Api.Transaction.Info.Response;
using TransactionApprove = PayNlSdk.Api.Transaction.Approve.Request;
using TransactionDecline = PayNlSdk.Api.Transaction.Decline.Request;
using TransactionGetService = PayNlSdk.Api.Transaction.GetService.Request;
using TransactionInfo = PayNlSdk.Api.Transaction.Info.Request;
using TransactionRefund = PayNlSdk.Api.Transaction.Refund.Request;

namespace PayNlSdk;

/// <summary>
/// Generic Transaction service helper class.
/// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
/// </summary>
public class Transaction : ITransaction
{

    private readonly IClient _webClient;

    /// <summary>
    /// Initializes a new transaction object
    /// </summary>
    /// <param name="webClient"></param>
    public Transaction(IClient webClient)
    {
        _webClient = webClient;
    }


    /// <summary>
    /// Checks whether a transaction has a status of PAID
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if PAID, false otherwise</returns>
    public bool IsPaid(string transactionId)
    {
        return CheckTransactionStatus(transactionId, response =>
            response?.PaymentDetails?.State == Enums.PaymentStatus.PAID);
    }


    /// <summary>
    /// Checks whether a transaction has a status of CANCELLED
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if CANCELLED, false otherwise</returns>
    public bool IsCancelled(string transactionId)
    {
        return CheckTransactionStatus(transactionId, response =>
            response?.PaymentDetails?.State == Enums.PaymentStatus.CANCEL);
    }



    /// <summary>
    /// Checks whether a transaction has a status of PENDING
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if PENDING, false otherwise</returns>
    public bool IsPending(string transactionId)
    {
        return CheckTransactionStatus(transactionId, response =>
            (response?.PaymentDetails?.State == Enums.PaymentStatus.PENDING_1) ||
            (response?.PaymentDetails?.State == Enums.PaymentStatus.PENDING_2) ||
            (response?.PaymentDetails?.State == Enums.PaymentStatus.PENDING_3) ||
            (response?.PaymentDetails?.State == Enums.PaymentStatus.VERIFY) ||
            (response?.PaymentDetails?.StateName == "PENDING"));
    }



    /// <summary>
    /// Checks whether a transaction has a status of VERIFY
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if VERIFY, false otherwise</returns>
    public bool IsVerify(string transactionId)
    {
        return CheckTransactionStatus(transactionId, response =>
            (response?.PaymentDetails?.State == Enums.PaymentStatus.VERIFY) ||
            (response?.PaymentDetails?.StateName == "VERIFY"));
    }

    /// <summary>
    /// Helper method to safely check transaction status with proper exception handling
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <param name="statusCheck">Function to check the status from response</param>
    /// <returns>True if status check passes, false if check fails or exception occurs</returns>
    private bool CheckTransactionStatus(string transactionId, Func<Response?, bool> statusCheck)
    {
        try
        {
            var request = new TransactionInfo { TransactionId = transactionId };
            _webClient.PerformRequest(request);
            return statusCheck(request.Response);
        }
        catch (PayNlException)
        {
            // Network or API errors should return false for status checks
            return false;
        }
    }



    /// <summary>
    /// Checks whether a status is a REFUND or REFUNDING status
    /// </summary>
    /// <param name="status">Transaction status</param>
    /// <returns>True if REFUND or REFUNDING, false otherwise</returns>
    public static bool IsRefund(Enums.PaymentStatus status)
    {
        return status == Enums.PaymentStatus.REFUND || status == Enums.PaymentStatus.REFUNDING;
    }

    /// <summary>
    /// Checks whether a status is a REFUNDING status, meaning a refund is currently being processed.
    /// </summary>
    /// <param name="status">Transaction status</param>
    /// <returns>True if REFUNDING, false otherwise</returns>
    public static bool IsRefunding(Enums.PaymentStatus status)
    {
        return status == Enums.PaymentStatus.REFUNDING;
    }

    /// <summary>
    /// Query the service for all (current status) information on a transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <returns>Full response object with all information available</returns>
    public Response Info(string transactionId)
    {
        var request = new TransactionInfo { TransactionId = transactionId };

        _webClient.PerformRequest(request);
        return request.Response;
    }

    /// <summary>
    /// Return service information.
    /// This API returns merchant info and all the available payment options per country for a given service.
    /// This is an important API if you want to build your own payment screens.
    /// </summary>
    /// <param name="paymentMethodId">The id of the payment method (optional)</param>
    /// <returns>Full response with all service information</returns>
    public Api.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId = null)
    {
        var request = new TransactionGetService
        {
            PaymentMethodId = paymentMethodId
        };

        _webClient.PerformRequest(request);
        return request.Response;
    }

    /// <summary>
    /// Performs a (partial) refund call on an existing transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <param name="description">Reason for the refund. May be null.</param>
    /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
    /// <param name="processDate">Date to process the refund. May be null.</param>
    /// <returns>Full response including the Refund ID</returns>
    public Api.Transaction.Refund.Response Refund(string transactionId, string description = null, decimal? amount = null, DateTime? processDate = null)
    {
        var request = new TransactionRefund
        {
            TransactionId = transactionId,
            Description = description,
            Amount = amount,
            ProcessDate = processDate
        };

        _webClient.PerformRequest(request);
        return request.Response;
    }

    /// <summary>
    /// function to approve a suspicious transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <returns>Full response Whether the transaction was approved</returns>
    public Api.Transaction.Approve.Response Approve(string transactionId)
    {
        var request = new TransactionApprove
        {
            TransactionId = transactionId
        };

        _webClient.PerformRequest(request);
        return request.Response;
    }

    /// <summary>
    /// function to decline a suspicious transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <returns>Full response including the message about the decline</returns>
    public Api.Transaction.Decline.Response Decline(string transactionId)
    {
        TransactionDecline request = new TransactionDecline();
        request.TransactionId = transactionId;

        _webClient.PerformRequest(request);
        return request.Response;
    }


    /// <summary>
    /// Creates a transaction start request model
    /// </summary>
    /// <param name="amount">The amount.  Will be rounded at 2 digits after comma.</param>
    /// <param name="ipAddress">The IP address of the customer</param>
    /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
    /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
    /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
    /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
    /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
    /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
    /// <returns>Transaction Start Request</returns>
    public static Request CreateTransactionRequest(decimal amount, string ipAddress, string returnUrl, int? paymentOptionId = null, int? paymentSubOptionId = null, bool testMode = false, string transferType = null, string transferValue = null)
    {
        var request = new Request
        {
            Amount = (int)Math.Round(amount * 100),
            IPAddress = ipAddress,
            ReturnUrl = returnUrl,
            PaymentOptionId = paymentOptionId,
            PaymentOptionSubId = paymentSubOptionId,
            TestMode = testMode,
            TransferType = transferType,
            TransferValue = transferValue
        };
        return request;
    }


    /// <summary>
    /// Performs a request to start a transaction.
    /// </summary>
    /// <returns>Full response object including Transaction ID</returns>
    public Api.Transaction.Start.Response Start(Request request)
    {

        _webClient.PerformRequest(request);
        return request.Response;
    }
}

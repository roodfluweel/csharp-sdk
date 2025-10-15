using PayNLSdk.Api.Transaction.Approve;
using PayNLSdk.Enums;
using System;
using Request = PayNLSdk.Api.Transaction.Start.Request;

namespace PayNLSdk;

/// <summary>
/// All api calls against transactions
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Approve a suspicious transaction
    /// </summary>
    /// <param name="transactionId">The transaction id</param>
    Response Approve(string transactionId);

    /// <summary>
    /// Function to decline a suspicious transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <returns>Full response including the message about the decline</returns>
    Api.Transaction.Decline.Response Decline(string transactionId);

    /// <summary>
    /// Return service information.
    /// This API returns merchant info and all the available payment options per country for a given service.
    /// This is an important API if you want to build your own payment screens.
    /// </summary>
    /// <param name="paymentMethodId">optional, the payment method ID</param>
    /// <returns>Full response with all service information</returns>
    Api.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId = null);

    /// <summary>
    /// Query the service for all (current status) information on a transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <returns>Full response object with all information available</returns>
    Api.Transaction.Info.Response Info(string transactionId);

    /// <summary>
    /// Checks whether a transaction has a status of CANCELLED
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if CANCELLED, false otherwise</returns>
    bool IsCancelled(string transactionId);

    /// <summary>
    /// Checks whether a transaction has a status of PAID
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if PAID, false otherwise</returns>
    bool IsPaid(string transactionId);

    /// <summary>
    /// Checks whether a transaction has a status of PENDING
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if PENDING, false otherwise</returns>
    bool IsPending(string transactionId);

    /// <summary>
    /// Checks whether a transaction has a status of VERIFY
    /// </summary>
    /// <param name="transactionId">Transaction Id</param>
    /// <returns>True if VERIFY, false otherwise</returns>
    bool IsVerify(string transactionId);

    /// <summary>
    /// Performs a (partial) refund call on an existing transaction
    /// </summary>
    /// <param name="transactionId">Transaction ID</param>
    /// <param name="description">Reason for the refund. May be null.</param>
    /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
    /// <param name="processDate">Date to process the refund. May be null.</param>
    /// <returns>Full response including the Refund ID</returns>
    Api.Transaction.Refund.Response Refund(string transactionId, string description = null, decimal? amount = null, DateTime? processDate = null);

    /// <summary>
    /// If a customer has chosen to pay per transaction this API needs to be called. 
    /// </summary>
    /// <remarks>
    /// The parameter bankId for GiroPay has a length of 8 characters, see http://www.giropay.de for more information.
    /// After the payment extra GET parameters will be added to the orderReturnUrl.
    /// These parameters are also available if the payment is cancelled, or if the payment could not be completed.
    /// </remarks>
    Api.Transaction.Start.Response Start(Request request);
}

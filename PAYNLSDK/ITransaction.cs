using PayNLSdk.Api.Transaction.Approve;
using PayNLSdk.Enums;
using System;
using Request = PayNLSdk.Api.Transaction.Start.Request;

namespace PayNLSdk;

public interface ITransaction
{
    /// <summary>
    /// Approve a suspicious transaction
    /// </summary>
    /// <param name="transactionId">The transaction id</param>
    Response Approve(string transactionId);
    Api.Transaction.Decline.Response Decline(string transactionId);
    Api.Transaction.GetService.Response GetService();
    Api.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId);
    Api.Transaction.Info.Response Info(string transactionId);
    bool IsCancelled(string transactionId);
    bool IsPaid(string transactionId);
    bool IsPending(string transactionId);
    bool IsVerify(string transactionId);
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

using System;
using PayNLSdk.API.Transaction.Approve;
using PayNLSdk.API.Transaction.Decline;
using PayNLSdk.API.Transaction.GetService;
using PayNLSdk.API.Transaction.Info;
using PayNLSdk.API.Transaction.Refund;
using PayNLSdk.API.Transaction.Start;
using PayNLSdk.Enums;

namespace PayNLSdk
{
    public interface ITransaction
    {
        /// <summary>
        /// Approve a suspicious transaction
        /// </summary>
        /// <param name="transactionId">The transaction id</param>
        API.Transaction.Approve.Response Approve(string transactionId);
        API.Transaction.Decline.Response Decline(string transactionId);
        API.Transaction.GetService.Response GetService();
        API.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId);
        API.Transaction.Info.Response Info(string transactionId);
        bool IsCancelled(string transactionId);
        bool IsPaid(string transactionId);
        bool IsPending(string transactionId);
        bool IsVerify(string transactionId);
        API.Transaction.Refund.Response Refund(string transactionId, string description = null, decimal? amount = null, DateTime? processDate = null);
        /// <summary>
        /// If a customer has chosen to pay per transaction this API needs to be called. 
        /// </summary>
        /// <remarks>
        /// The parameter bankId for GiroPay has a length of 8 characters, see http://www.giropay.de for more information.
        /// After the payment extra GET parameters will be added to the orderReturnUrl.
        /// These parameters are also available if the payment is cancelled, or if the payment could not be completed.
        /// </remarks>
        API.Transaction.Start.Response Start(API.Transaction.Start.Request request);
    }
}

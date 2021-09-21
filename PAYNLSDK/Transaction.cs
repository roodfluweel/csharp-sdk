using System;
using Microsoft.Extensions.Logging;
using PayNLSdk.API.Transaction.Info;
using PayNLSdk.Enums;
using PayNLSdk.Exceptions;
using PayNLSdk.Net;
using Request = PayNLSdk.API.Transaction.Start.Request;
using TransactionGetService = PayNLSdk.API.Transaction.GetService.Request;
using TransactionInfo = PayNLSdk.API.Transaction.Info.Request;
using TransactionRefund = PayNLSdk.API.Transaction.Refund.Request;
using TransactionApprove = PayNLSdk.API.Transaction.Approve.Request;
using TransactionDecline = PayNLSdk.API.Transaction.Decline.Request;

namespace PayNLSdk
{
    /// <summary>
    ///     Generic Transaction service helper class.
    ///     Makes calling PAYNL Services easier and eliminates the need to fully initiate all Request objects.
    /// </summary>
    public class Transaction : ITransaction
    {
        private readonly Logger<Transaction> _logger;

        private readonly IClient _webClient;

        /// <summary>
        ///     Initializes a new transaction object
        /// </summary>
        /// <param name="webClient"></param>
        /// <param name="logger"></param>
        public Transaction(IClient webClient, Logger<Transaction> logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        /// <inheritdoc />
        public bool IsPaid(string transactionId)
        {
            var request = new TransactionInfo
            {
                TransactionId = transactionId
            };

            _webClient.PerformRequest(request);
            return request.Response.PaymentDetails.State == PaymentStatus.PAID;
        }

        /// <inheritdoc />
        public bool IsCancelled(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };
                _webClient.PerformRequest(request);
                return request.Response.PaymentDetails.State == PaymentStatus.CANCEL;
            }
            catch (PayNlException e)
            {
                _logger.LogError(e, "Unhandled exception on calling paynl");
                return false;
            }
        }

        /// <inheritdoc />
        public bool IsPending(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                _webClient.PerformRequest(request);
                return request.Response.PaymentDetails.State == PaymentStatus.PENDING_1 ||
                       request.Response.PaymentDetails.State == PaymentStatus.PENDING_2 ||
                       request.Response.PaymentDetails.State == PaymentStatus.PENDING_3 ||
                       request.Response.PaymentDetails.State == PaymentStatus.VERIFY ||
                       request.Response.PaymentDetails.StateName == "PENDING";
            }
            catch (PayNlException e)
            {
                _logger.LogError(e, "Unhandled exception on calling paynl");
                return false;
            }
        }

        /// <inheritdoc />
        public bool IsVerify(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                _webClient.PerformRequest(request);
                return request.Response.PaymentDetails.State == PaymentStatus.VERIFY ||
                       request.Response.PaymentDetails.StateName == "VERIFY";
            }
            catch (PayNlException e)
            {
                _logger.LogError(e, "Unhandled exception on calling paynl");
                return false;
            }
        }

        /// <inheritdoc />
        public Response Info(string transactionId)
        {
            var request = new TransactionInfo
            {
                TransactionId = transactionId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <inheritdoc />
        public API.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId = null)
        {
            var request = new TransactionGetService
            {
                PaymentMethodId = paymentMethodId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <inheritdoc />
        public API.Transaction.Refund.Response Refund(string transactionId, string description = null,
            decimal? amount = null, DateTime? processDate = null)
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

        /// <inheritdoc />
        public API.Transaction.Approve.Response Approve(string transactionId)
        {
            var request = new TransactionApprove
            {
                TransactionId = transactionId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <inheritdoc />
        public API.Transaction.Decline.Response Decline(string transactionId)
        {
            var request = new TransactionDecline
            {
                TransactionId = transactionId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }


        /// <inheritdoc />
        public API.Transaction.Start.Response Start(Request request)
        {
            _webClient.PerformRequest(request);
            return request.Response;
        }


        /// <summary>
        ///     Checks whether a status is a REFUND or REFUNDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUND or REFUNDING, false otherwise</returns>
        public static bool IsRefund(PaymentStatus status)
        {
            return status == PaymentStatus.REFUND || status == PaymentStatus.REFUNDING;
        }

        /// <summary>
        ///     Checks whether a status is a REFUNDING status, meaning a refund is currently being processed.
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUNDING, false otherwise</returns>
        public static bool IsRefunding(PaymentStatus status)
        {
            return status == PaymentStatus.REFUNDING;
        }


        /// <summary>
        ///     Creates a transaction start request model
        /// </summary>
        /// <param name="amount">The amount.  Will be rounded at 2 digits after comma.</param>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">
        ///     In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList
        ///     in the getService function).
        /// </param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
        /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
        /// <returns>Transaction Start Request</returns>
        public static Request CreateTransactionRequest(decimal amount, string ipAddress, string returnUrl,
            int? paymentOptionId = null, int? paymentSubOptionId = null, bool testMode = false,
            string transferType = null, string transferValue = null)
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
    }
}

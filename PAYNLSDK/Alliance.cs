using System.Diagnostics.CodeAnalysis;
using PAYNLSDK.Net;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Alliance : IAlliance
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Create a new API client for the Alliance API
        /// </summary>
        /// <param name="webClient"></param>
        public Alliance(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public PAYNLSDK.API.Alliance.GetMerchant.GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PAYNLSDK.API.Alliance.GetMerchant.GetMerchantResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddMerchant.AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddMerchant.AddMerchantResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddService.AddServiceResult AddService(API.Alliance.AddService.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddService.AddServiceResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddInvoice.AddInvoiceResult AddInvoice(API.Alliance.AddInvoice.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddInvoice.AddInvoiceResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.GetMerchants.GetMerchantsResult GetMerchants(API.Alliance.GetMerchants.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.GetMerchants.GetMerchantsResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.Suspend.SuspendResult Suspend(API.Alliance.Suspend.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.Suspend.SuspendResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.Unsuspend.UnsuspendResult Unsuspend(API.Alliance.Unsuspend.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.Unsuspend.UnsuspendResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.SetPackage.SetPackageResult SetPackage(API.Alliance.SetPackage.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.SetPackage.SetPackageResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.MarkReady.MarkReadyResult MarkReady(API.Alliance.MarkReady.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.MarkReady.MarkReadyResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddClearing.AddClearingResult AddClearing(API.Alliance.AddClearing.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddClearing.AddClearingResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddBankAccount.AddBankAccountResult AddBankAccount(API.Alliance.AddBankAccount.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddBankAccount.AddBankAccountResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.GetCategories.GetCategoriesResult GetCategories(API.Alliance.GetCategories.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.GetCategories.GetCategoriesResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.GetAvailablePaymentOptions.GetAvailablePaymentOptionsResult GetAvailablePaymentOptions(API.Alliance.GetAvailablePaymentOptions.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.GetAvailablePaymentOptions.GetAvailablePaymentOptionsResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.EnablePaymentOption.EnablePaymentOptionResult EnablePaymentOption(API.Alliance.EnablePaymentOption.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.EnablePaymentOption.EnablePaymentOptionResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.DisablePaymentOption.DisablePaymentOptionResult DisablePaymentOption(API.Alliance.DisablePaymentOption.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.DisablePaymentOption.DisablePaymentOptionResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddDocument.AddDocumentResult AddDocument(API.Alliance.AddDocument.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddDocument.AddDocumentResult>(response);
        }
    }
}

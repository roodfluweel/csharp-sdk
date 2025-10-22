namespace PAYNLSDK
{
    /// <summary>
    /// Alliance methods
    /// </summary>
    public interface IAlliance
    {
        /// <summary>
        /// This function can be used to retrieve alliance merchant information. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        API.Alliance.GetMerchant.GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request);

        /// <summary>
        /// Adds the merchant.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddMerchantResult.</returns>
        API.Alliance.AddMerchant.AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request);

        /// <summary>
        /// Adds a service for a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddServiceResult.</returns>
        API.Alliance.AddService.AddServiceResult AddService(API.Alliance.AddService.Request request);
        
        /// <summary>
        /// Inserts a transaction to collect an invoice fee. 
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.AddInvoice.AddInvoiceResult.</returns>
        API.Alliance.AddInvoice.AddInvoiceResult AddInvoice(API.Alliance.AddInvoice.Request request);

        /// <summary>
        /// Get a list of merchants
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.GetMerchants.GetMerchantsResult.</returns>
        API.Alliance.GetMerchants.GetMerchantsResult GetMerchants(API.Alliance.GetMerchants.Request request);

        /// <summary>
        /// Suspend a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.Suspend.SuspendResult.</returns>
        API.Alliance.Suspend.SuspendResult Suspend(API.Alliance.Suspend.Request request);

        /// <summary>
        /// Unsuspend a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.Unsuspend.UnsuspendResult.</returns>
        API.Alliance.Unsuspend.UnsuspendResult Unsuspend(API.Alliance.Unsuspend.Request request);

        /// <summary>
        /// Set package for a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.SetPackage.SetPackageResult.</returns>
        API.Alliance.SetPackage.SetPackageResult SetPackage(API.Alliance.SetPackage.Request request);

        /// <summary>
        /// Mark a merchant as ready
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.MarkReady.MarkReadyResult.</returns>
        API.Alliance.MarkReady.MarkReadyResult MarkReady(API.Alliance.MarkReady.Request request);

        /// <summary>
        /// Add clearing for a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.AddClearing.AddClearingResult.</returns>
        API.Alliance.AddClearing.AddClearingResult AddClearing(API.Alliance.AddClearing.Request request);

        /// <summary>
        /// Add bank account for a merchant with iDEAL verification
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.AddBankAccount.AddBankAccountResult.</returns>
        API.Alliance.AddBankAccount.AddBankAccountResult AddBankAccount(API.Alliance.AddBankAccount.Request request);

        /// <summary>
        /// Get website categories
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.GetCategories.GetCategoriesResult.</returns>
        API.Alliance.GetCategories.GetCategoriesResult GetCategories(API.Alliance.GetCategories.Request request);

        /// <summary>
        /// Get available payment options for a service
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.GetAvailablePaymentOptions.GetAvailablePaymentOptionsResult.</returns>
        API.Alliance.GetAvailablePaymentOptions.GetAvailablePaymentOptionsResult GetAvailablePaymentOptions(API.Alliance.GetAvailablePaymentOptions.Request request);

        /// <summary>
        /// Enable a payment option for a service
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.EnablePaymentOption.EnablePaymentOptionResult.</returns>
        API.Alliance.EnablePaymentOption.EnablePaymentOptionResult EnablePaymentOption(API.Alliance.EnablePaymentOption.Request request);

        /// <summary>
        /// Disable a payment option for a service
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.DisablePaymentOption.DisablePaymentOptionResult.</returns>
        API.Alliance.DisablePaymentOption.DisablePaymentOptionResult DisablePaymentOption(API.Alliance.DisablePaymentOption.Request request);

        /// <summary>
        /// Upload a document
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.AddDocument.AddDocumentResult.</returns>
        API.Alliance.AddDocument.AddDocumentResult AddDocument(API.Alliance.AddDocument.Request request);
    }
}

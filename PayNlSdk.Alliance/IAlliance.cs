using PayNlSdk.Api.Alliance.AddBankAccount;
using PayNlSdk.Api.Alliance.AddClearing;
using PayNlSdk.Api.Alliance.AddInvoice;
using PayNlSdk.Api.Alliance.AddMerchant;
using PayNlSdk.Api.Alliance.AddService;
using PayNlSdk.Api.Alliance.DisablePaymentOption;
using PayNlSdk.Api.Alliance.Document.Add;
using PayNlSdk.Api.Alliance.EnablePaymentOption;
using PayNlSdk.Api.Alliance.GetAvailablePaymentOptions;
using PayNlSdk.Api.Alliance.GetCategories;
using PayNlSdk.Api.Alliance.GetMerchant;
using PayNlSdk.Api.Alliance.GetMerchants;
using PayNlSdk.Api.Alliance.MarkReady;
using PayNlSdk.Api.Alliance.SetPackage;
using PayNlSdk.Api.Alliance.Statistics;
using PayNlSdk.Api.Alliance.Suspend;
using PayNlSdk.Api.Alliance.Unsuspend;
using GetMerchantRequest = PayNlSdk.Api.Alliance.GetMerchant.Request;
using GetMerchantsRequest = PayNlSdk.Api.Alliance.GetMerchants.Request;

namespace PayNlSdk;

/// <summary>
/// Alliance methods
/// </summary>
public interface IAlliance
{
    /// <summary>
    /// Retrieve detailed information for a single merchant.
    /// </summary>
    GetMerchantResult? GetMerchant(GetMerchantRequest request);

    /// <summary>
    /// Retrieve merchants that are linked to the alliance.
    /// </summary>
    GetMerchantsResult? GetMerchants(GetMerchantsRequest request);

    /// <summary>
    /// Create a new merchant.
    /// </summary>
    AddMerchantResult? AddMerchant(Api.Alliance.AddMerchant.Request request);

    /// <summary>
    /// Add a new service for an existing merchant.
    /// </summary>
    AddServiceResult? AddService(Api.Alliance.AddService.Request request);

    /// <summary>
    /// Initiate the process to link a bank account to a merchant.
    /// </summary>
    AddBankAccountResult? AddBankAccount(Api.Alliance.AddBankAccount.Request request);

    /// <summary>
    /// Create an invoice that will be settled with the merchant.
    /// </summary>
    AddInvoiceResult? AddInvoice(Api.Alliance.AddInvoice.Request request);

    /// <summary>
    /// Apply an additional clearing amount for the merchant.
    /// </summary>
    AddClearingResult? AddClearing(Api.Alliance.AddClearing.Request request);

    /// <summary>
    /// Mark the merchant as ready for processing.
    /// </summary>
    MarkReadyResult? MarkReady(Api.Alliance.MarkReady.Request request);

    /// <summary>
    /// Change the package associated with the merchant.
    /// </summary>
    SetPackageResult? SetPackage(Api.Alliance.SetPackage.Request request);

    /// <summary>
    /// Suspend a merchant.
    /// </summary>
    SuspendResult? Suspend(Api.Alliance.Suspend.Request request);

    /// <summary>
    /// Unsuspend a merchant.
    /// </summary>
    UnsuspendResult? Unsuspend(Api.Alliance.Unsuspend.Request request);

    /// <summary>
    /// Retrieve available payment options for a service.
    /// </summary>
    GetAvailablePaymentOptionsResult? GetAvailablePaymentOptions(Api.Alliance.GetAvailablePaymentOptions.Request request);

    /// <summary>
    /// Retrieve service categories.
    /// </summary>
    GetCategoriesResult? GetCategories(Api.Alliance.GetCategories.Request request);

    /// <summary>
    /// Enable a payment option for a service.
    /// </summary>
    EnablePaymentOptionResult? EnablePaymentOption(Api.Alliance.EnablePaymentOption.Request request);

    /// <summary>
    /// Disable a payment option for a service.
    /// </summary>
    DisablePaymentOptionResult? DisablePaymentOption(Api.Alliance.DisablePaymentOption.Request request);

    /// <summary>
    /// Upload supporting documentation for a merchant or account.
    /// </summary>
    Response? UploadDocument(Api.Alliance.Document.Add.Request request);

    /// <summary>
    /// Retrieve aggregated statistics for the alliance.
    /// </summary>
    StatisticsResult? GetStatistics(Api.Alliance.Statistics.Request request);
}

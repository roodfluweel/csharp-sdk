using System.Diagnostics.CodeAnalysis;
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
using PayNlSdk.Net;
using PayNlSdk.Utilities;
using GetMerchantRequest = PayNlSdk.Api.Alliance.GetMerchant.Request;
using GetMerchantsRequest = PayNlSdk.Api.Alliance.GetMerchants.Request;

namespace PayNlSdk;

/// <summary>
/// Entry point for Alliance specific API calls.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Alliance : IAlliance
{
    private readonly IClient _webClient;

    /// <summary>
    /// Create a new API client for the Alliance API.
    /// </summary>
    public Alliance(IClient webClient)
    {
        _webClient = webClient;
    }

    /// <inheritdoc />
    public GetMerchantResult GetMerchant(GetMerchantRequest request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetMerchantResult>(response);
    }

    /// <inheritdoc />
    public GetMerchantsResult GetMerchants(GetMerchantsRequest request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetMerchantsResult>(response);
    }

    /// <inheritdoc />
    public AddMerchantResult AddMerchant(Api.Alliance.AddMerchant.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddMerchantResult>(response);
    }

    /// <inheritdoc />
    public AddServiceResult AddService(Api.Alliance.AddService.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddServiceResult>(response);
    }

    /// <inheritdoc />
    public AddBankAccountResult AddBankAccount(Api.Alliance.AddBankAccount.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddBankAccountResult>(response);
    }

    /// <inheritdoc />
    public AddInvoiceResult AddInvoice(Api.Alliance.AddInvoice.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddInvoiceResult>(response);
    }

    /// <inheritdoc />
    public AddClearingResult AddClearing(Api.Alliance.AddClearing.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddClearingResult>(response);
    }

    /// <inheritdoc />
    public MarkReadyResult MarkReady(Api.Alliance.MarkReady.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<MarkReadyResult>(response);
    }

    /// <inheritdoc />
    public SetPackageResult SetPackage(Api.Alliance.SetPackage.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<SetPackageResult>(response);
    }

    /// <inheritdoc />
    public SuspendResult Suspend(Api.Alliance.Suspend.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<SuspendResult>(response);
    }

    /// <inheritdoc />
    public UnsuspendResult Unsuspend(Api.Alliance.Unsuspend.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<UnsuspendResult>(response);
    }

    /// <inheritdoc />
    public GetAvailablePaymentOptionsResult GetAvailablePaymentOptions(Api.Alliance.GetAvailablePaymentOptions.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetAvailablePaymentOptionsResult>(response);
    }

    /// <inheritdoc />
    public GetCategoriesResult GetCategories(Api.Alliance.GetCategories.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetCategoriesResult>(response);
    }

    /// <inheritdoc />
    public EnablePaymentOptionResult EnablePaymentOption(Api.Alliance.EnablePaymentOption.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<EnablePaymentOptionResult>(response);
    }

    /// <inheritdoc />
    public DisablePaymentOptionResult DisablePaymentOption(Api.Alliance.DisablePaymentOption.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<DisablePaymentOptionResult>(response);
    }

    /// <inheritdoc />
    public Response UploadDocument(Api.Alliance.Document.Add.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<Response>(response);
    }

    /// <inheritdoc />
    public StatisticsResult GetStatistics(Api.Alliance.Statistics.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<StatisticsResult>(response);
    }
}

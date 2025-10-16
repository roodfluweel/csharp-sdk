using PayNlSdk.Api.Alliance.AddInvoice;
using PayNlSdk.Api.Alliance.AddMerchant;
using PayNlSdk.Api.Alliance.AddService;
using PayNlSdk.Api.Alliance.GetMerchant;
using PayNlSdk.Net;
using System.Diagnostics.CodeAnalysis;
using Request = PayNlSdk.Api.Alliance.GetMerchant.Request;
using PayNlSdk.Utilities;

namespace PayNlSdk;

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
    public GetMerchantResult GetMerchant(Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<GetMerchantResult>(response);
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
    public AddInvoiceResult AddInvoice(Api.Alliance.AddInvoice.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return JsonSerialization.Deserialize<AddInvoiceResult>(response);
    }
}
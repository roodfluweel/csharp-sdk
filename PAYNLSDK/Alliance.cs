using PayNLSdk.Api.Alliance.AddInvoice;
using PayNLSdk.Api.Alliance.AddMerchant;
using PayNLSdk.Api.Alliance.AddService;
using PayNLSdk.Api.Alliance.GetMerchant;
using PayNLSdk.Net;
using System.Diagnostics.CodeAnalysis;
using Request = PayNLSdk.Api.Alliance.GetMerchant.Request;

namespace PayNLSdk;

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
        return Newtonsoft.Json.JsonConvert.DeserializeObject<GetMerchantResult>(response);
    }

    /// <inheritdoc />
    public AddMerchantResult AddMerchant(Api.Alliance.AddMerchant.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<AddMerchantResult>(response);
    }

    /// <inheritdoc />
    public AddServiceResult AddService(Api.Alliance.AddService.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<AddServiceResult>(response);
    }

    /// <inheritdoc />
    public AddInvoiceResult AddInvoice(Api.Alliance.AddInvoice.Request request)
    {
        var response = _webClient.PerformRequest(request);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<AddInvoiceResult>(response);
    }
}
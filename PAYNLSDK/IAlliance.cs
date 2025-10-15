using PayNLSdk.Api.Alliance.AddInvoice;
using PayNLSdk.Api.Alliance.AddMerchant;
using PayNLSdk.Api.Alliance.AddService;
using PayNLSdk.Api.Alliance.GetMerchant;
using Request = PayNLSdk.Api.Alliance.GetMerchant.Request;

namespace PayNLSdk;

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
    GetMerchantResult GetMerchant(Request request);

    /// <summary>
    /// Adds the merchant.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>AddMerchantResult.</returns>
    AddMerchantResult AddMerchant(Api.Alliance.AddMerchant.Request request);

    /// <summary>
    /// Adds a service for a merchant
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>AddServiceResult.</returns>
    AddServiceResult AddService(Api.Alliance.AddService.Request request);

    /// <summary>
    /// Inserts a transaction to collect an invoice fee. 
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>API.Alliance.AddInvoice.AddInvoiceResult.</returns>
    AddInvoiceResult AddInvoice(Api.Alliance.AddInvoice.Request request);
}
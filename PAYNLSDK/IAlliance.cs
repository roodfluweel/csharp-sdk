using PayNlSdk.Api.Alliance.AddInvoice;
using PayNlSdk.Api.Alliance.AddMerchant;
using PayNlSdk.Api.Alliance.AddService;
using PayNlSdk.Api.Alliance.GetMerchant;
using Request = PayNlSdk.Api.Alliance.GetMerchant.Request;

namespace PayNlSdk;

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
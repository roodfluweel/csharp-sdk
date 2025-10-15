using PayNLSdk.Api.PaymentMethod.Get;
using PayNLSdk.Net;
using PaymentMethodGet = PayNLSdk.Api.PaymentMethod.Get.Request;
using PaymentMethodGetAll = PayNLSdk.Api.PaymentMethod.GetAll.Request;

namespace PayNLSdk;

/// <summary>
/// Generic Payment Method service helper class.
/// Makes calling PAYNL Services easier and eliminates the need to fully initiate all Request objects.
/// </summary>
public class PaymentMethod
{
    private readonly IClient _webClient;

    /// <summary>
    /// Create a new PaymentMethod object
    /// </summary>
    /// <param name="webClient"></param>
    public PaymentMethod(IClient webClient)
    {
        _webClient = webClient;
    }

    /// <summary>
    /// Get information for the requested payment method.
    /// </summary>
    /// <param name="paymentMethodId">Payment Method ID</param>
    /// <returns>Response containing the payment method data</returns>
    public Response Get(Enums.PaymentMethodId paymentMethodId)
    {
        var request = new PaymentMethodGet
        {
            PaymentMethodId = paymentMethodId
        };
        _webClient.PerformRequest(request);
        return request.Response;
    }

    /// <summary>
    /// Get information for all payment methods.
    /// </summary>
    /// <returns>Response containing a list of information for all payment methods</returns>
    public Api.PaymentMethod.GetAll.Response GetAll()
    {
        var request = new PaymentMethodGetAll();
        _webClient.PerformRequest(request);
        return request.Response;
    }
}

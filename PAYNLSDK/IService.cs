using PayNLSdk.Api.Service.GetCategories;

namespace PayNLSdk;

/// <summary>
/// A 
/// </summary>
public interface IService
{
    Response GetCategories(int? paymentOptionId = null);
}

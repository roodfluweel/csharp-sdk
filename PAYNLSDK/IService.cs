using PayNlSdk.Api.Service.GetCategories;

namespace PayNlSdk;

/// <summary>
/// A 
/// </summary>
public interface IService
{
    Response GetCategories(int? paymentOptionId = null);
}

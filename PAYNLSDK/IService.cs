using PayNLSdk.API.Service.GetCategories;

namespace PayNLSdk
{
    /// <summary>
    /// All api calls which are linked to setting up a service
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Returns a list of available service categories. If a payment option is specified, only the categories linked
        /// to the payment option is returned
        /// </summary>
        /// <param name="paymentOptionId">The ID of the payment profile</param>
        /// <returns></returns>
        Response GetCategories(int? paymentOptionId = null);
    }
}

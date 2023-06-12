namespace PayNLSdk
{
    /// <summary>
    /// function specific to the payment profiles
    /// </summary>
    public interface IPaymentProfileClient
    {
        /// <summary>
        /// Get details for a specific payment profile
        /// </summary>
        /// <param name="paymentProfileId">Payment profile ID</param>
        /// <returns>Payment profile response</returns>
        PayNLSdk.API.PaymentProfile.Get.Response Get(int paymentProfileId);

        /// <summary>
        /// Get details for all payment profiles
        /// </summary>
        /// <returns>List of payment profile info</returns>
        PayNLSdk.API.PaymentProfile.GetAll.Response GetAll();

        /// <summary>
        /// Get payment profile information for all your available profiles for the specified service category
        /// </summary>
        /// <param name="categoryId">The ID of the category of the service the payment options are used for</param>
        /// <param name="programId">ID of the program for which the payment options are used. (Only available if the program option is enabled!)</param>
        /// <param name="paymentMethodId">Payment Method ID</param>
        /// <param name="showNotAllowedOnRegistration">Indicator wether to show profiles that are initially not allowed on registration. </param>
        /// <returns>Response containing the list of payment profile information</returns>
        PayNLSdk.API.PaymentProfile.GetAvailable.Response GetAvailable(int categoryId, int? programId = null, int? paymentMethodId = null, bool? showNotAllowedOnRegistration = null);
    }
}

namespace PayNlSdk.Api.PaymentProfile.GetAvailable;

/// <summary>
/// Returns a list of available service categories. If a payment option is specified, only the categories linked to the payment option is returned 
/// </summary>
public class Response : ResponseBase
{
    /// <summary>
    /// 
    /// </summary>
    public Objects.PaymentProfile[] PaymentProfiles { get; set; }
}

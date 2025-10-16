namespace PayNlSdk.Api;

/// <inheritdoc />
public class PayNlConfiguration : IPayNlConfiguration
{
    /// <inheritdoc />
    public PayNlConfiguration()
    {
    }

    /// <inheritdoc />
    public PayNlConfiguration(string serviceId, string apiToken)
    {
        ServiceId = serviceId;
        ApiToken = apiToken;
    }

    /// <summary>
    /// PAYNL Service ID
    /// </summary>
    public string ServiceId { get; set; }

    /// <summary>
    /// PAYNL API Token
    /// </summary>
    public string ApiToken { get; set; }
}

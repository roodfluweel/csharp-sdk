using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace PayNlSdk.Api.Alliance.AddService;

/// <summary>
/// Class Request for a new Service.
/// </summary>
/// <seealso cref="RequestBase" />
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 7;
    /// <inheritdoc />
    protected override string Controller => "Alliance";
    /// <inheritdoc />
    protected override string Method => "addService";
    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var retval = new NameValueCollection();

        AddIfNotEmpty(retval, "merchantId", MerchantId);
        AddIfNotEmpty(retval, "name", Name);
        AddIfNotEmpty(retval, "description", Description);
        AddIfNotEmpty(retval, "categoryId", CategoryId);
        AddIfNotEmpty(retval, "publication", Publication);

        for (var i = 0; i < PublicationUrls.Count; i++)
        {
            retval.Add($"publicationUrls[{i}]", PublicationUrls[i]);
        }

        for (var i = 0; i < PaymentOptions.Count; i++)
        {
            var option = PaymentOptions[i];
            retval.Add($"paymentOptions[{i}][id]", option.Id.ToString(CultureInfo.InvariantCulture));

            foreach (var setting in option.Settings)
            {
                retval.Add($"paymentOptions[{i}][settings][{setting.Key}]", setting.Value);
            }
        }

        foreach (var kvp in ExchangeParameters)
        {
            retval.Add($"exchange[{kvp.Key}]", kvp.Value);
        }

        if (AlwaysSendExchange.HasValue && !ExchangeParameters.ContainsKey("alwaysSendExchange"))
        {
            retval.Add("exchange[alwaysSendExchange]", AlwaysSendExchange.Value ? "1" : "0");
        }

        AddIfNotEmpty(retval, "pluginVersionId", PluginVersionId);
        AddIfNotEmpty(retval, "contactPhone", ContactPhone);

        return retval;
    }

    private static void AddIfNotEmpty(NameValueCollection collection, string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            collection.Add(key, value);
        }
    }

    /// <summary>
    /// Gets or sets the merchant identifier.
    /// </summary>
    /// <value>The merchant identifier.</value>
    public string? MerchantId { get; set; }

    /// <summary>
    /// Gets or sets the description of the way you are using the payment methods
    /// </summary>
    /// <value>The publication.</value>
    public string? Publication { get; set; }

    /// <summary>
    /// Gets or sets The ID of the category that best descriptions your service.
    /// For a list of available categories, see API_Service_v1::getCategories().
    /// </summary>
    /// <value>The category identifier.</value>
    public string? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the description of the service. It is important to be as acurate as possible.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the name of the service.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }

    /// <summary>
    /// An array of payment options (id &amp; settings) you want to use for this service.
    /// For a list of available payment option ids, see API_PaymentProfile_v1::getAvailable()
    /// </summary>
    public List<PaymentProfile> PaymentOptions { get; } = new();

    /// <summary>
    /// Optional list of publication URLs that describe the service content.
    /// </summary>
    public List<string> PublicationUrls { get; } = new();

    /// <summary>
    /// Additional exchange configuration parameters.
    /// </summary>
    public Dictionary<string, string> ExchangeParameters { get; } = new();

    /// <summary>
    /// Force the exchange to be triggered regardless of other settings.
    /// </summary>
    public bool? AlwaysSendExchange { get; set; }

    /// <summary>
    /// Optional plugin version identifier.
    /// </summary>
    public string? PluginVersionId { get; set; }

    /// <summary>
    /// Optional contact phone number for the merchant.
    /// </summary>
    public string? ContactPhone { get; set; }

    /// <summary>
    /// Load the raw response and perform any actions along with it.
    /// </summary>
    protected override void PrepareAndSetResponse()
    {
        // do nothing
    }
}

/// <summary>
/// Payment profile
/// For a list of available payment option ids, see API_PaymentProfile_v1::getAvailable()
/// </summary>
public class PaymentProfile
{
    /// <summary>
    /// ID of the payment profile
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Settings that belong to this payment profile.
    /// </summary>
    public Dictionary<string, string> Settings { get; } = new();

    /// <summary>
    /// Convenience helper to add a single setting value.
    /// </summary>
    public void AddSetting(string key, string value)
    {
        Settings[key] = value;
    }
}

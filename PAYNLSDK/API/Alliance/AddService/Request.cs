using System.Collections.Generic;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Alliance.AddService;

/// <summary>
/// Class Request for a new Service.
/// </summary>
/// <seealso cref="RequestBase" />
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 4;
    /// <inheritdoc />
    protected override string Controller => "Alliance";
    /// <inheritdoc />
    protected override string Method => "addService";
    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var retval = new NameValueCollection();
        retval.Add("merchantId", MerchantId);
        retval.Add("name", Name);
        retval.Add("description", Description);
        retval.Add("categoryId", CategoryId);
        retval.Add("publication", Publication);

        if (PaymentOptions.Count > 0)
        {
            for (int i = 0; i < PaymentOptions.Count; i++)
            {
                retval.Add("paymentOptions[" + i + "][id]", PaymentOptions[i].Id.ToString());
                retval.Add("paymentOptions[" + i + "][settings]", PaymentOptions[i].Settings);
            }
        }

        return retval;
    }

    /// <summary>
    /// Gets or sets the merchant identifier.
    /// </summary>
    /// <value>The merchant identifier.</value>
    public string MerchantId { get; set; }

    /// <summary>
    /// Gets or sets the description of the way you are using the payment methods
    /// </summary>
    /// <value>The publication.</value>
    public string Publication { get; set; }

    /// <summary>
    /// Gets or sets The ID of the category that best descriptions your service. 
    /// For a list of available categories, see API_Service_v1::getCategories().
    /// </summary>
    /// <value>The category identifier.</value>
    public string CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the description of the service. It is important to be as acurate as possible.
    /// </summary>
    /// <value>The description.</value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the name of the service.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// An array of payment options (id &amp; settings) you want to use for this service.
    /// For a list of available payment option ids, see API_PaymentProfile_v1::getAvailable() 
    /// </summary>
    public List<PaymentProfile> PaymentOptions = new List<PaymentProfile>();

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
    /// Array of settings that belong to this payment profile. 
    /// </summary>
    public string Settings { get; set; }
}
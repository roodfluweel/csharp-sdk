using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Newtonsoft.Json;

namespace PayNLSdk.API.Alliance.AddService
{
    /// <summary>
    /// Class Request for a new Service.
    /// </summary>
    /// <seealso cref="PayNLSdk.API.RequestBase" />
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
            retval.Add("merchantId", MerchantId);
            retval.Add("name", Name);
            retval.Add("description", Description);
            retval.Add("categoryId", CategoryId);
            retval.Add("publication", Publication);
            retval.Add("publicationUrls", JsonConvert.SerializeObject(PublicationUrls));
            retval.Add("paymentOptions", JsonConvert.SerializeObject(PaymentOptions));

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
        /// If the payment options are used on multiple locations, ALL these locations must be specified.
        ///     Each location is an element in this array (eg.array(
        ///     "www.example.com/cart",
        ///     "shopping.example.com/?page=cart",
        ///     "www.google.com/examplecart")).
        /// (only available if this option is enabled for your company.If this option is not enabled
        /// and you want to use the payment options on multiple locations, add a services for each location!)
        /// </summary>
        public List<string> PublicationUrls { get; set; }

        /// <summary>
        /// payment options you want to use for this service.
        /// For a list of available payment option ids see 
        /// <see cref="PAYNLSDK.PaymentProfile.GetAvailable(int,Nullable{int},Nullable{int},Nullable{bool})"/>
        /// </summary>
        public List<AddServicePaymentOptions> PaymentOptions { get; set; }

        /// <summary>
        /// Load the raw response and perform any actions along with it.
        /// </summary>
        protected override void PrepareAndSetResponse()
        {
            // do nothing   
        }
    }

    /// <summary>
    /// For a list of available payment option ids see 
    /// <see cref="PAYNLSDK.PaymentProfile.GetAvailable(int,Nullable{int},Nullable{int},Nullable{bool})"/>
    /// </summary>
    public sealed class AddServicePaymentOptions
    {
        /// <summary>
        /// ID of the payment option
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Array of settings that belong to this payment profile. 
        /// </summary>
        [JsonProperty("settings")]
        public List<string> Settings { get; set; }
    }
}

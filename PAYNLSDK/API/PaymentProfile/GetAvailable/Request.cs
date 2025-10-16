using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Converters;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.PaymentProfile.GetAvailable;

public class Request : RequestBase
{
    /// <summary>
    /// The ID of the category of the service the payment options are used for. 
    /// For a list of available categories, see <see cref="PayNlSdk.Api.Service.GetCategories"/>
    /// </summary>
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    /// <summary>
    /// ID of the program for which the payment options are used. (Only available if the program option is enabled!)
    /// </summary>
    [JsonPropertyName("programId")]
    public int? ProgramId { get; set; }

    /// <summary>
    /// Optional ID of the payment method
    /// </summary>
    [JsonPropertyName("paymentMethodId")]
    public int? PaymentMethodId { get; set; }

    /// <summary>
    /// Indicator wether to show profiles that are initially not allowed on registration. 
    /// </summary>
    [JsonPropertyName("showNotAllowedOnRegistration"), JsonConverter(typeof(BooleanConverter))]
    public bool? ShowNotAllowedOnRegistration { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "PaymentProfile";

    /// <inheritdoc />
    protected override string Method => "getAvailable";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotNull(CategoryId, "CategoryId");
        nvc.Add("categoryId", CategoryId.ToString());

        if (!ParameterValidator.IsNonEmptyInt(ProgramId))
        {
            nvc.Add("programId", ProgramId.ToString());
        }

        if (!ParameterValidator.IsNonEmptyInt(PaymentMethodId))
        {
            nvc.Add("paymentMethodId", PaymentMethodId.ToString());
        }

        if (!ParameterValidator.IsNull(ShowNotAllowedOnRegistration))
        {
            nvc.Add("ShowNotAllowedOnRegistration", ((bool)ShowNotAllowedOnRegistration) ? "1" : "0");
        }

        return nvc;
    }

    public Response Response { get { return (Response)response; } }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        Objects.PaymentProfile[] pm = JsonSerialization.Deserialize<Objects.PaymentProfile[]>(RawResponse);
        Response r = new Response();
        r.PaymentProfiles = pm;
        response = r;
    }
}

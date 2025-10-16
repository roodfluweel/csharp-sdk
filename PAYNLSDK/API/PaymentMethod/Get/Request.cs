using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.PaymentMethod.Get;

/// <summary>
/// The model to request a particular paymentMethod
/// </summary>
public class Request : RequestBase
{
    /// <summary>
    /// The paymentMethod to be used
    /// </summary>
    [JsonPropertyName("paymentMethodId")]
    public Enums.PaymentMethodId PaymentMethodId { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "PaymentMethod";

    /// <inheritdoc />
    protected override string Method => "get";

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        var allParameters = new NameValueCollection();

        ParameterValidator.IsNotNull(PaymentMethodId, "PaymentMethodId");
        allParameters.Add("paymentMethodId", PaymentMethodId.ToString());

        return allParameters;
    }

    public Response Response => (Response)response;

    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        Objects.PaymentMethod pm = JsonSerialization.Deserialize<Objects.PaymentMethod>(RawResponse);
        Response r = new Response
        {
            PaymentMethod = pm
        };
        response = r;
    }
}

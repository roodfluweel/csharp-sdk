using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Validate.IsPayServerIp;

/// <inheritdoc />
/// <summary>
/// Request to validate whether the ipaddress is a PAY server ip
/// Implements the <see cref="RequestBase" />
/// </summary>
/// <seealso cref="RequestBase" />
public class Request : RequestBase
{
    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    /// <value>The ip address.</value>
    [JsonProperty("ipAddress")]
    public string IpAddress { get; set; }

    /// <inheritdoc />
    public override bool RequiresApiToken => false;

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "Validate";

    /// <inheritdoc />
    protected override string Method => "isPayServerIp";

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        var nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(IpAddress, "IpAddress");
        nvc.Add("ipAddress", IpAddress);

        return nvc;
    }

    /// <summary>
    /// Gets the response.
    /// </summary>
    /// <value>The response.</value>
    public Response Response => (Response)response;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonConvert.DeserializeObject<Response>(RawResponse);
    }
}

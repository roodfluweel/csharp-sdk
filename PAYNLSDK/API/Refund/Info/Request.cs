using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.Refund.Info;

/// <summary>
/// 
/// </summary>
public class Request : RequestBase
{
    /// <summary>
    /// create new instance
    /// </summary>
    /// <param name="refundId">Refund ID</param>
    public Request(string refundId)
    {
        RefundId = refundId;
    }

    /// <summary>
    /// The refund ID.
    /// </summary>
    public string RefundId { get; set; }

    /// <inheritdoc />
    protected override int Version => 3;

    /// <inheritdoc />
    protected override string Controller => "Refund";

    /// <inheritdoc />
    protected override string Method => "info";


    /// <inheritdoc />
    public override bool RequiresApiToken => true;

    /// <summary>
    /// 
    /// </summary>
    public override bool RequiresServiceId => true;

    /// <inheritdoc />
    public override System.Collections.Specialized.NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotNull(RefundId, "RefundId");
        nvc.Add("refundId", RefundId);

        return nvc;
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonSerialization.Deserialize<Response>(RawResponse);
        if (!Response.Request.Result)
        {
            // toss
            throw new PayNlException(Response.Request.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Response Response => (Response)response;
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System.Collections.Specialized;

namespace PayNlSdk.Api.Transaction.Info;

public class Request : RequestBase
{
    /// <summary>
    /// Mandatory transaction identifier
    /// </summary>
    [System.ComponentModel.DataAnnotations.Required]
    public string TransactionId { get; set; }

    /// <summary>
    /// Unique code related to the order.
    /// </summary>
    public string EntranceCode { get; set; }

    /// <inheritdoc />
    protected override int Version => 5;

    /// <inheritdoc />
    protected override string Controller => "Transaction";

    /// <inheritdoc />
    protected override string Method => "info";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
        nvc.Add("transactionId", TransactionId);

        if (!ParameterValidator.IsEmpty(EntranceCode))
        {
            nvc.Add("entranceCode", EntranceCode);
        }
        return nvc;
    }
    public Response Response => (Response)response;

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonSerialization.Deserialize<Response>(RawResponse);
    }

}

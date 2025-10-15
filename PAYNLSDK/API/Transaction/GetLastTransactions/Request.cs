using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.Api.Transaction.GetLastTransactions;

public class Request : RequestBase
{
    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    [JsonPropertyName("paid")]
    public bool? Paid { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    public override bool RequiresServiceId
    {
        get
        {
            return true;
        }
    }
    /// <inheritdoc />
    protected override int Version
    {
        get { return 5; }
    }

    /// <inheritdoc />
    protected override string Controller
    {
        get { return "Transaction"; }
    }

    /// <inheritdoc />
    protected override string Method
    {
        get { return "getLastTransactions"; }
    }

    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();
        if (!ParameterValidator.IsNull(MerchantId))
        {
            nvc.Add("merchantId", MerchantId);
        }
        if (!ParameterValidator.IsNull(Paid))
        {
            nvc.Add("paid", ((bool)Paid) ? "1" : "0");
        }
        if (!ParameterValidator.IsNull(Limit))
        {
            nvc.Add("limit", Limit.ToString());
        }
        return nvc;
    }

    public Response Response { get { return (Response)response; } }

    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = JsonSerialization.Deserialize<Response>(RawResponse);
    }
}

using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;
using System;
using System.Collections.Specialized;
using System.Globalization;

namespace PayNlSdk.Api.Merchant.Clearing;

public class Request : RequestBase
{
    protected override int Version => 4;

    protected override string Controller => "merchant";

    protected override string Method => "addClearing";

    /// <summary>
    ///  The amount to clear, will round on 2 decimals
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// The merchant to clear
    /// </summary>
    public string? MerchantId { get; set; }

    /// <summary>
    /// The content category Id.
    /// </summary>
    public string? ContentCategoryId { get; set; }

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();

        ParameterValidator.IsNotNull(Amount, "Amount");
        nvc.Add("amount", Math.Round(Amount * 100).ToString(CultureInfo.InvariantCulture));
        nvc.Add("merchantId", MerchantId);
        nvc.Add("contentCategoryId", ContentCategoryId);

        return nvc;
    }

    public Response Response { get { return (Response)response; } }

    /// <inheritdoc />
    /// <exception cref="NotImplementedException"></exception>
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }
        response = Response.FromRawResponse(RawResponse);
        if (response == null)
        {
            throw new PayNlException("Failed to deserialize response");
        }

        if (Response.Request == null || !Response.Request.Result)
        {
            throw new PayNlException("Request failed");
        }
    }
}

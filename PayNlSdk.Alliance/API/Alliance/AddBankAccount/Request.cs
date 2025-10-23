using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.AddBankAccount;

/// <summary>
/// Request payload for the Alliance/addBankaccount endpoint.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 7;

    /// <inheritdoc />
    protected override string Controller => "Alliance";

    /// <inheritdoc />
    protected override string Method => "addBankaccount";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (string.IsNullOrWhiteSpace(MerchantId))
        {
            throw new ValidationException("MerchantId is required");
        }

        if (string.IsNullOrWhiteSpace(ReturnUrl))
        {
            throw new ValidationException("ReturnUrl is required");
        }

        parameters.Add("merchantId", MerchantId);
        parameters.Add("returnUrl", ReturnUrl);

        if (BankId.HasValue)
        {
            parameters.Add("bankId", BankId.Value.ToString());
        }

        if (PaymentOptionId.HasValue)
        {
            parameters.Add("paymentOptionId", PaymentOptionId.Value.ToString());
        }

        return parameters;
    }

    /// <summary>
    /// The identifier of the merchant to link the bank account to.
    /// </summary>
    public string MerchantId { get; set; } = string.Empty;

    /// <summary>
    /// The URL to redirect the merchant to once the flow completes.
    /// </summary>
    public string ReturnUrl { get; set; } = string.Empty;

    /// <summary>
    /// Optional iDEAL bank identifier to preselect a bank.
    /// </summary>
    public int? BankId { get; set; }

    /// <summary>
    /// Optional payment option identifier that should be used for the flow.
    /// </summary>
    public int? PaymentOptionId { get; set; }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        // No post-processing required.
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Converters;
using PayNLSdk.Enums;

namespace PayNLSdk.Objects;

/// <summary>
/// General details regarding the payment
/// </summary>
public class PaymentDetails
{
    /// <summary>
    /// Amount of the session (in cents, eg. 1235)
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; protected set; }

    /// <summary>
    /// Currency Amount of the session (in cents, eg. 1235) 
    /// </summary>
    [JsonPropertyName("currencyAmount")]
    public int CurrencyAmount { get; protected set; }

    /// <summary>
    /// The total amount paid for this transaction
    /// </summary>
    [JsonPropertyName("paidAmount")]
    public string PaidAmount { get; protected set; }

    /// <summary>
    /// The total currency amount paid for this transaction
    /// </summary>
    [JsonPropertyName("paidCurrencyAmount")]
    public string PaidCurrencyAmount { get; protected set; }

    /// <summary>
    /// Basic amount without the cost
    /// </summary>
    [JsonPropertyName("paidBase")]
    public string PaidBase { get; protected set; }

    /// <summary>
    /// Payment costs paid by the customer (ex. VAT) 
    /// </summary>
    [JsonPropertyName("paidCosts")]
    public string PaidCosts { get; protected set; }

    /// <summary>
    /// VAT rate for costs 
    /// </summary>
    [JsonPropertyName("paidCostsVat")]
    public string PaidCostsVat { get; protected set; }

    /// <summary>
    /// Currency of the payment 
    /// </summary>
    [JsonPropertyName("PaidCurreny")]
    public string PaidCurrency { get; protected set; }

    /// <summary>
    /// Number of payment attempts 
    /// </summary>
    [JsonPropertyName("paidAttemps")]
    public string PaidAttemps { get; protected set; }

    /// <summary>
    /// Duration of the phonecall (only for phone payments)
    /// </summary>
    [JsonPropertyName("paidDuration")]
    public string PaidDuration { get; protected set; }

    /// <summary>
    /// Order description 
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; protected set; }

    /// <summary>
    /// Time passed from payment start to payment finish
    /// </summary>
    [JsonPropertyName("processTime")]
    public string ProcessTime { get; protected set; }

    /// <summary>
    /// Payment Status indicator
    /// </summary>
    [JsonPropertyName("state")]
    public PaymentStatus State { get; protected set; }

    /// <summary>
    /// Payment status name
    /// </summary>
    [JsonPropertyName("stateName")]
    public string StateName { get; protected set; }

    /// <summary>
    /// Payment status description
    /// </summary>
    [JsonPropertyName("stateDescription")]
    public string StateDescription { get; protected set; }

    /// <summary>
    /// Indicator whether or not the exchange URL has been called succesfully
    /// </summary>
    [JsonPropertyName("exchange")]
    //public ExchangeState Exchange { get; protected set; }
    public string Exchange { get; protected set; }

    /// <summary>
    /// Indicator whether or not the transaction is refunded
    /// </summary>
    [JsonPropertyName("storno"), JsonConverter(typeof(BooleanConverter))]
    public bool Storno { get; protected set; }

    /// <summary>
    /// The payment options used (eq. iDeal/creditcard) 
    /// </summary>
    [JsonPropertyName("paymentOptionId")]
    public int PaymentOptionId { get; protected set; }

    /// <summary>
    /// The payment options sub id used (eq. the selected bank for iDeal) 
    /// </summary>
    [JsonPropertyName("paymentOptionSubId")]
    public int PaymentOptionSubId { get; protected set; }

    /// <summary>
    /// For creditcard transactions
    /// </summary>
    [JsonPropertyName("secure")]
    public Secure Secure { get; protected set; }

    /// <summary>
    /// Returns the 3d secure status
    /// </summary>
    [JsonPropertyName("secureStatus")]
    public string SecureStatus { get; protected set; }

    /// <summary>
    /// Name of the consumer
    /// </summary>
    [JsonPropertyName("identifierName")]
    public string IdentifierName { get; protected set; }

    /// <summary>
    /// Payment identifier that can be displayed to the customer for reference
    /// </summary>
    [JsonPropertyName("identifierPublic")]
    public string IdentifierPublic { get; protected set; }

    /// <summary>
    /// Customer ID, a unique hash based upon the bankaccount/creditcard number of the customer
    /// </summary>
    [JsonPropertyName("identifierHash")]
    public string IdentifierHash { get; protected set; }

    /// <summary>
    /// ID of the service/website for which the transaction is started
    /// </summary>
    [JsonPropertyName("serviceId")]
    public string ServiceId { get; protected set; }

    /// <summary>
    /// Name of the service/website
    /// </summary>
    [JsonPropertyName("serviceName")]
    public string ServiceName { get; protected set; }

    /// <summary>
    /// Description of the service/website
    /// </summary>
    [JsonPropertyName("serviceDescription")]
    public string ServiceDescription { get; protected set; }

    /// <summary>
    /// Date time of the moment the transaction was started
    /// </summary>
    [JsonPropertyName("created")]
    public string Created { get; protected set; }

    /// <summary>
    /// Date time of the last status change of the transaction
    /// </summary>
    [JsonPropertyName("modified")]
    public string Modified { get; protected set; }

    /// <summary>
    /// ID of the type of the payment method
    /// </summary>
    [JsonPropertyName("paymentMethodId")]
    public string PaymentMethodId { get; protected set; }

    /// <summary>
    /// Name of the type of the payment method
    /// </summary>
    [JsonPropertyName("paymentMethodName")]
    public string PaymentMethodName { get; protected set; }

    /// <summary>
    /// Description of the type of the payment method
    /// </summary>
    [JsonPropertyName("paymentMethodDescription")]
    public string PaymentMethodDescription { get; protected set; }

    /// <summary>
    /// Name of the payment profile used to pay the transaction
    /// </summary>
    [JsonPropertyName("paymentProfileName")]
    public string PaymentProfileName { get; protected set; }

    /// <summary>
    /// Gets or sets the Order number of the transaction .
    /// </summary>
    /// <value>The order number.</value>
    [JsonPropertyName("orderNumber")] public string OrderNumber { get; set; }

    /// <summary>
    /// Name of the creditcard supplier 
    /// </summary>
    [JsonPropertyName("cardBrand")] public string CardBrand { get; set; }

    /// <summary>
    /// Debit or credit 
    /// </summary>
    [JsonPropertyName("cardType")] public string CardType { get; set; }

    /// <summary>
    /// Countrycode of the creditcards origin 
    /// </summary>
    [JsonPropertyName("cardCountryCode")] public string CardCountryCode { get; set; }
}

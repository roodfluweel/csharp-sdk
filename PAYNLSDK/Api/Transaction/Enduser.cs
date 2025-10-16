using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Api.Transaction.Info;
using PayNlSdk.Converters;
using PayNlSdk.Enums;
using PayNlSdk.Objects;
using System;

namespace PayNlSdk.Api.Transaction;

/// <summary>
/// Provides details of the EndUser.
/// </summary>
public class EndUser
{
    // @DISABLED@
    //[JsonPropertyName("accessCode")]
    //public string AccessCode { get; set; }

    /// <summary>
    /// Unique reference of customer
    /// </summary>
    [JsonPropertyName("customerReference")]
    public string CustomerReference { get; set; }

    /// <summary>
    /// End User's Language
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; set; }

    /// <summary>
    /// End User's Initials
    /// </summary>
    [JsonPropertyName("initials")]
    public string Initials { get; set; }

    /// <summary>
    /// End User's Gender
    /// </summary>
    [JsonPropertyName("gender"), JsonConverter(typeof(GenderConverter))]
    public Gender? Gender { get; set; }

    /// <summary>
    /// End User's Last Name
    /// </summary>
    [JsonPropertyName("lastName")]
    public string Lastname { get; set; }

    /// <summary>
    /// End User's Date of Birth
    /// </summary>
    [JsonPropertyName("dob"), JsonConverter(typeof(DMYConverter))]
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// End User's Phone Number
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// End User's Email Address
    /// </summary>
    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    /// <summary>
    /// End User's Bank Account Number.
    /// Note in most cases the IBAN will be used.
    /// </summary>
    [JsonPropertyName("bankAccount")]
    public string BankAccount { get; set; }

    /// <summary>
    /// End User's IBAN
    /// </summary>
    [JsonPropertyName("iban")]
    public string IBAN { get; set; }

    /// <summary>
    /// End User's BIC
    /// </summary>
    [JsonPropertyName("bic")]
    public string BIC { get; set; }

    [JsonPropertyName("sendConfirmMail")]
    public bool? SendConfirmMail { get; set; }

    //[JsonPropertyName("confirmMailTemplate")]
    //public string ConfirmMailTemplate { get; set; }

    /// <summary>
    /// End User's Address
    /// </summary>
    [JsonPropertyName("address")]
    public Address Address { get; set; }

    /// <summary>
    /// End User's Invoice Address
    /// </summary>
    [JsonPropertyName("invoiceAddress")]
    public Address InvoiceAddress { get; set; }

    //[JsonPropertyName("saleData")]
    //public SaleData? SalesData { get; protected set; }

    /// <summary>
    /// End User's Payment Details
    /// </summary>
    [JsonPropertyName("paymentDetails")]
    public PaymentDetails PaymentDetails { get; set; }

    /// <summary>
    /// End User's Storno Details if applicable
    /// </summary>
    [JsonPropertyName("stornoDetails")]
    public StornoDetails StornoDetails { get; set; }

    /// <summary>
    /// End User's Stats Details if applicable
    /// </summary>
    [JsonPropertyName("statsDetails")]
    public StatsDetails StatsDetails { get; set; }

    /// <summary>
    /// Company information of the EndUser
    /// </summary>
    [JsonPropertyName("company")]
    public Company Company { get; set; }

}

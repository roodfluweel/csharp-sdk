using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PayNlSdk.Api.Alliance.GetMerchant;

/// <summary>
/// The result of the Alliance/GetMerchant call
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GetMerchantResult
{
    [JsonPropertyName("request")] public GetMerchantResult.Request request { get; set; }
    [JsonPropertyName("merchantId")] public string merchantId { get; set; }
    [JsonPropertyName("merchantName")] public string merchantName { get; set; }
    [JsonPropertyName("services")] public Service[] services { get; set; }
    [JsonPropertyName("balance")] public int BalanceInCents { get; set; }
    [JsonIgnore] public decimal Balance => Math.Round(BalanceInCents / 100m);
    [JsonPropertyName("documents")] public Document[] documents { get; set; }
    [JsonPropertyName("accounts")] public Account[] accounts { get; set; }
    [JsonPropertyName("bankaccounts")] public Bankaccount[] bankaccounts { get; set; }
    [JsonPropertyName("public_info")] public PublicInfo public_info { get; set; }
    [JsonPropertyName("contract")] public Contract contract { get; set; }

    public class Request
    {
        [JsonPropertyName("result")] public bool result { get; set; }
        [JsonPropertyName("errorId")] public string errorId { get; set; }
        [JsonPropertyName("errorMessage")] public string errorMessage { get; set; }
    }

    public class PublicInfo
    {
        public string merchantId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string typeName { get; set; }
        public PostalAddress postalAddress { get; set; }
        public string cocNumber { get; set; }
        public string vatNumber { get; set; }
        public string image { get; set; }
        public List<ContactData> contactData { get; set; }
    }

    public class PostalAddress
    {
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string zipCode { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }

    public class Contract
    {
        public string packageType { get; set; }
        public string invoiceAllowed { get; set; }
        public string payoutInterval { get; set; }
        public string createdDate { get; set; }
        public string acceptedDate { get; set; }
        public string deletedDate { get; set; }
    }

    public class Service
    {
        public string serviceId { get; set; }
        public string serviceName { get; set; }
    }

    public class Document
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("type_id")]
        public string type_id { get; set; }
        [JsonPropertyName("type_name")]
        public string type_name { get; set; }
        /// <summary>
        /// Can be one of these values: 1 (Requested), 2 (Uploaded), 3 (Approved), 4 (Rejected), 5 (Expired)
        /// </summary>
        [JsonPropertyName("status_id")]
        public int status_id { get; set; }
        [JsonPropertyName("status_name")]
        public string status_name { get; set; }
        [JsonPropertyName("expires")]
        public string expires { get; set; }
    }

    public class Account
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("account_id")]
        public string account_id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("accepted")]
        public string accepted { get; set; }
        [JsonPropertyName("access")]
        public string access { get; set; }
        [JsonPropertyName("ubo")]
        public string ubo { get; set; }
        [JsonPropertyName("authorised_to_sign")]
        public string authorised_to_sign { get; set; }
        [JsonPropertyName("signature_label")]
        public string signature_label { get; set; }
        [JsonPropertyName("documents")]
        public Document[] documents { get; set; }
    }

    public class Bankaccount
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("bankaccountHolder")]
        public string bankaccountHolder { get; set; }
        [JsonPropertyName("bankaccountNumber")]
        public string bankaccountNumber { get; set; }
        [JsonPropertyName("bic")]
        public string bic { get; set; }
        [JsonPropertyName("countryCode")]
        public string countryCode { get; set; }
    }

    public class ContactData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}

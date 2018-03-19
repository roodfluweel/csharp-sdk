﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Merchant.Get
{
    public class Response : ResponseBase
    {
        public static Get.Response FromRawResponse(string response)
        {
            return JsonConvert.DeserializeObject<Get.Response>(response);
        }

        [JsonProperty("request")] public ResultInfo request { get; set; }
        public string merchantId { get; set; }
        public string merchantName { get; set; }
        public Service[] services { get; set; }
        public string balance { get; set; }
        public Document[] documents { get; set; }
        public Account[] accounts { get; set; }
        public string bankaccounts { get; set; }
        public Public_Info public_info { get; set; }
        public Contract contract { get; set; }


        public class ResultInfo
        {
            public string result { get; set; }
            public string errorId { get; set; }
            public string errorMessage { get; set; }
        }

        public class Public_Info
        {
            public string merchantId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string typeName { get; set; }
            [JsonProperty("postalAddress")] public PostalAddress PostalAddress { get; set; }
            public string cocNumber { get; set; }
            public string vatNumber { get; set; }
            public string image { get; set; }
            public string contactData { get; set; }
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
            public string id { get; set; }
            public string type_id { get; set; }
            public string type_name { get; set; }
            public string status_id { get; set; }
            public string status_name { get; set; }
            public string expires { get; set; }
        }

        public class Account
        {
            public string id { get; set; }
            public string account_id { get; set; }
            public string name { get; set; }
            public string accepted { get; set; }
            public string access { get; set; }
            public string ubo { get; set; }
            public string authorised_to_sign { get; set; }
            public string signature_label { get; set; }
            public Document[] documents { get; set; }
        }

    }
}
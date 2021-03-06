﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    public class Request : RequestBase
    {
        public Request()
        {
            Accounts = new List<Account>();
        }

        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "addMerchant";
        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection { };

            retval.Add("merchant[name]", FullName);
            retval.Add("merchant[coc]", Coc);

            retval.Add("merchant[vat]", Vat);
            retval.Add("merchant[street]", Street);
            retval.Add("merchant[houseNumber]", HouseNumber);
            retval.Add("merchant[houseNumberAddition]", HouseNumberAddition);
            retval.Add("merchant[postalCode]", PostalCode);
            retval.Add("merchant[city]", City);
            retval.Add("merchant[countryCode]", Country);

            for (var i = 0; i < Accounts.Count; i++)
            {
                var account = Accounts[i];
                retval.Add($"accounts[{i}][email]", account.Email);
                retval.Add($"accounts[{i}][firstname]", account.FirstName);
                retval.Add($"accounts[{i}][lastname]", account.LastName);
                retval.Add($"accounts[{i}][gender]", account.Gender);
                retval.Add($"accounts[{i}][authorizedToSign]", account.AuthorizedToSign.ToString());
                retval.Add($"accounts[{i}][ubo]", account.UltimateBeneficialOwner ? "1" : "0");
                retval.Add($"accounts[{i}][uboPercentage]", 0.ToString());
                retval.Add($"accounts[{i}][useCompanyAuth]", "1");
                retval.Add($"accounts[{i}][hasAccess]", "1");
                retval.Add($"accounts[{i}][language]", "1");
            }

            return retval;
        }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string HouseNumber { get; set; }

        public string HouseNumberAddition { get; set; }

        public string Street { get; set; }

        public string Vat { get; set; }

        public string Coc { get; set; }

        public string FullName { get; set; }

        public List<Account> Accounts { get; set; }

        public class Account
        {
            [JsonProperty("primary")]
            public bool Primary { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            /// <summary>
            /// "male" or "female"
            /// </summary>
            [JsonProperty("gender")]
            [JsonConverter(typeof(StringEnumConverter))]
            public string Gender { get; set; }

            /// <summary>
            /// 0 not authorised, 1 authorised independently, 2  shared authorized to sign
            /// </summary>
            [JsonProperty("authorisedToSign")]
            public AuthorisedToSignEnum AuthorizedToSign { get; set; }

            /// <summary>
            /// Ultimate beneficial owner (25% of more shares)
            /// </summary>
            [JsonProperty("ubo")]
            public bool UltimateBeneficialOwner { get; set; }

            public enum GenderEnum
            {
                M,
                F
            }

            public enum AuthorisedToSignEnum
            {
                NotAuthorised = 0,
                AuthorisedIndependently = 1,
                SharedAuthorizedToSign = 2
            }
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing   
        }
    }
}

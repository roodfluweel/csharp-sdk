using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;

namespace PayNLSdk.API.Merchant.Add
{
    public class Request : RequestBase
    {
        /**
         * Add a merchant
         *
         * Create a new submerchant.
         * The format of the option array is as follows
         * array(
         *      // Required
         *      'companyName' => 'The Name',
         *      'cocNumber' => '123456789',
         *      'street' => 'Street',
         *      'houseNumber' => '123',
         *      'postalCode' => '1234 AA',
         *      'city' => 'City',
         *      'accounts' => array(
         *          // Minimum of 1 account, you can add more, one account must be primary, the other accounts cannot be primary
         *          array(
         *              'primary' => true, // One account must be primary
         *              'email' => 'email@test.nl',
         *              'firstname' => 'First',
         *              'lastname' => 'Last',
         *              'gender' => 'male', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          ),
         *          array(
         *              'primary' => false,
         *              'email' => 'email2@test.nl',
         *              'firstname' => 'Mede',
         *              'lastname' => 'Eigenaar',
         *              'gender' => 'female', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          )
         *       ),
         *      // Optional
         *      Do you want to send a registration email to the accounts.
         *      The options are:
         *      0 - No email is sent
         *      1 - The default registration email is sent
         *      2 - The shortened alliance registration email is sent
         *      'sendEmail' => 1, // see above
         *      'countryCode' => 'NL',
         *      'bankAccountOwner' => 'Firstname Lastname',
         *      'bankAccountNumber' => 'NL91ABNA0417164300',
         *      'bankAccountBIC' => 'ABNANL2A',
         *      'vatNumber' => 'NL123412413',
         *      'packageName' => 'Alliance', // Alliance or AlliancePlus
         *
         *      Set to true if you want to be able to add a debit invoice to the account of this merchant.
         *      Your invoice will be subtracted from the merchants account.
         *      You will need to ask the merchant for permission before you can set this value to true
         *      'settleBalance' => false, // see above
         *      'payoutInterval' => 'week' //day, week or month
         *  )
         */

        [JsonRequired]
        [Required]
        public string CompanyName { get; set; }

        /// <summary>
        /// The cocNumber of the merchant
        /// </summary>
        public string CocNumber { get; set; }
        /// <summary>
        /// The street of the merchant
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// The housenumber of the merchant
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// The postalcode of the merchant
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The city of the merchant
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The accounts linked to the merchant
        /// </summary>
        public List<Account> Accounts { get; set; }

        /// <summary>
        /// Optional
        ///      Do you want to send a registration email to the accounts.
        /// The options are:
        ///      0 - No email is sent
        ///      1 - The default registration email is sent
        ///      2 - The shortened alliance registration email is sent
        /// </summary>
        [JsonProperty("sendEmail")]
        public int? SendEmail { get; set; }

        /// <summary>
        /// The Two letter (ISO) country code
        /// </summary>
        [JsonProperty("countryCode")]
        public string TwoLetterCountryCode { get; set; }

        /// <summary>
        /// The owner of the bank accounts
        /// </summary>
        [JsonProperty("bankAccountOwner")]
        public string BankAccountOwner { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The BIC code of the BankAccountNumber
        /// </summary>
        [JsonProperty("bankAccountBIC")]
        public string BankAccountBic { get; set; }

        /// <summary>
        /// The VAT number
        /// </summary>
        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }

        /// <summary>
        /// Alliance or AlliancePlus
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }
        /// <summary>
        /// settleBalance
        /// Set to true if you want to be able to add a debit invoice to the account of this merchant.
        /// Your invoice will be subtracted from the merchants account.
        /// You will need to ask the merchant for permission before you can set this value to true
        /// </summary>
        [JsonProperty("settleBalance")]
        public bool SettleBalance { get; set; }

        /// <summary>
        /// options are day, week or month
        /// </summary>
        [JsonProperty("payoutInterval")]
        public string PayoutInterval { get; set; }

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
            public string Gender { get; set; }

            /// <summary>
            /// 0 not authorised, 1 authorised independently, 2  shared authorized to sign
            /// </summary>
            [JsonProperty("authorisedToSign")]
            public int AuthorizedToSign { get; set; }

            /// <summary>
            /// Ultimate beneficial owner (25% of more shares)
            /// </summary>
            [JsonProperty("ubo")]
            public bool UltimateBeneficialOwner { get; set; }
        }

        /// <inheritdoc />
        protected override int Version { get; }
        /// <inheritdoc />
        protected override string Controller => "Merchant";
        /// <inheritdoc />
        protected override string Method => "Add";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(CompanyName, "CompanyName");
            nvc.Add("amount", CompanyName);
            
            if(string.IsNullOrWhiteSpace(CocNumber) == false) { nvc.Add("cocNumber", CocNumber); }
            if (string.IsNullOrWhiteSpace(Street) == false) { nvc.Add("street", Street); }
            if (string.IsNullOrWhiteSpace(HouseNumber) == false) { nvc.Add("housenumber", HouseNumber); }
            if (string.IsNullOrWhiteSpace(PostalCode) == false) { nvc.Add("postalCode", PostalCode); }
            if (string.IsNullOrWhiteSpace(City) == false) { nvc.Add("city", City); }
            // if (Accounts == null) { nvc.Add("city", Accounts); }

            // TODO ADD MORE!!!

            return nvc;
        }
        
        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<API.Merchant.Add.Response>(RawResponse);
            if (!response.Request.Result)
            {
                // toss
                throw new PayNlException(response.Request.Message);
            }
        }
    }
}

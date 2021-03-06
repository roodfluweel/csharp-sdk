﻿using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.BankAccountNumberInternational
{
    /// <inheritdoc />
    /// <summary>
    /// Validation request class for an international bank account number
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// Bank account number
        /// </summary>
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <inheritdoc />
        public override bool RequiresApiToken => false;// base.RequiresApiToken;

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "BankAccountNumberInternational";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(BankAccountNumber, "bankAccountNumber");
            nvc.Add("bankAccountNumber", BankAccountNumber);

            return nvc;
        }

        /// <summary>  Gets the response.</summary>
        /// <value>The response.</value>
        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}

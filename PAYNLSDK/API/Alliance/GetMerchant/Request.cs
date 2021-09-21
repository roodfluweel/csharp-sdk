﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayNLSdk.API.Transaction.Info;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;

namespace PayNLSdk.API.Alliance.GetMerchant
{
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 4;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "getMerchant";

        /// <summary>
        /// the merchant Id to request
        /// </summary>
        public string MerchantId { get; set; }

        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection { { "merchantId", MerchantId } };
            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            // response = JsonConvert.DeserializeObject<GetMerchantResult>(RawResponse);

        }
    }
}

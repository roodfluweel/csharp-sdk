﻿using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.Validate.SOFI
{
    /// <summary>
    /// The request data for the Validate SOFI call
    /// </summary>
    public class Request : RequestBase
    {
        [JsonProperty("sofi")]
        public string SOFI { get; set; }

        public override bool RequiresApiToken => false;

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "SOFI";

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(SOFI, "sofi");
            nvc.Add("sofi", SOFI);

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

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

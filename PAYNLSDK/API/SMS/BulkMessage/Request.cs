using Newtonsoft.Json;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.SMS.BulkMessage
{
    /// <summary>
    /// The request data for the SMS BulkMessage call
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// The sender organisation
        /// </summary>
        [JsonProperty("org")]
        public string Sender { get; set; }

        /// <summary>
        /// the destination recipient
        /// </summary>
        [JsonProperty("dest")]
        public string Recipient { get; set; }

        /// <summary>
        /// the body of the sms
        /// </summary>
        [JsonProperty("body")]
        public string Message { get; set; }

        //[JsonProperty("starttime")]
        //public int SendTime { get; set; }

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "SMS";

        /// <inheritdoc />
        protected override string Method => "sendBulkMessage";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(Sender, "Sender");
            nvc.Add("org", Sender);

            ParameterValidator.IsNotEmpty(Recipient, "Recipient");
            nvc.Add("dest", Recipient);

            ParameterValidator.IsNotEmpty(Message, "Message");
            nvc.Add("body", Message);

            return nvc;
        }
        /// <summary>
        /// the result of the call
        /// </summary>
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

using Newtonsoft.Json;
using PAYNLSDK.API;

namespace PayNLSdk.API.Merchant.Clearing
{
    /// <summary>
    /// The response from a Merchant Clearing call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// The reference of the clearing. 
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// get response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static Response FromRawResponse(string response)
        {
            return JsonConvert.DeserializeObject<Response>(response);
        }
    }
}

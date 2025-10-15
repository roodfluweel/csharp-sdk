using Newtonsoft.Json;

namespace PayNLSdk.Api.Merchant.Clearing;

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

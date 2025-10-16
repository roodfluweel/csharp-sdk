using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Utilities;

namespace PayNlSdk.Api.Merchant.Clearing;

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
        return JsonSerialization.Deserialize<Response>(response);
    }
}

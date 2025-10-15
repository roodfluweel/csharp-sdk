using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Enums;

namespace PayNLSdk.Objects;

/// <summary>
///  Service Details
/// </summary>
public class Service
{
    /// <summary>
    /// Service ID
    /// </summary>
    [JsonPropertyName("id")]
    public string ID { get; set; }

    /// <summary>
    /// Service Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Service Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The way the service is presented to the customer (eg. an URL or name of an advertisement) 
    /// </summary>
    [JsonPropertyName("publication")]
    public string Publication { get; set; }

    /// <summary>
    /// Base path of the images for the payment options 
    /// </summary>
    [JsonPropertyName("basePath")]
    public string BasePath { get; set; }

    /// <summary>
    /// ID of the module
    /// </summary>
    [JsonPropertyName("module")]
    public int Module { get; set; }

    /// <summary>
    /// ID of the submodule
    /// </summary>
    [JsonPropertyName("subModule")]
    public int SubModule { get; set; }

    /// <summary>
    /// Active state for this Service
    /// </summary>
    [JsonPropertyName("state")]
    public ActiveState State { get; set; }

    /// <summary>
    /// Target url after a successfull payment 
    /// </summary>
    [JsonPropertyName("successUrl")]
    public string SuccessUrl { get; set; }

    /// <summary>
    /// Target url after a failed payment
    /// </summary>
    [JsonPropertyName("errorUrl")]
    public string ErrorUrl { get; set; }

}

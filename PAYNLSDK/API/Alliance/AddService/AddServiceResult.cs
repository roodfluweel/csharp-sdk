using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNLSdk.Api.Alliance.AddService;

/// <summary>
///     Class result class for a Add Service call
/// </summary>
public class AddServiceResult : ResponseBase
{
    /// <summary>
    /// The newly created service identifier (SL-****-****)
    /// </summary>
    [JsonPropertyName("serviceId")]
    public string ServiceId { get; set; }
}

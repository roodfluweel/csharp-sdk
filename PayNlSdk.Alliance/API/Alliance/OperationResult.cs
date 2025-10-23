using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance;

/// <summary>
/// Generic result wrapper for simple Alliance operations.
/// </summary>
public class OperationResult : ResponseBase
{
    /// <summary>
    /// Indicates whether the request succeeded.
    /// </summary>
    [JsonIgnore]
    public bool Success => Request?.Result ?? false;
}

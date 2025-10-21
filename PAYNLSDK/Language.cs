using PayNlSdk.Api.Language;
using PayNlSdk.Net;
using PayNlSdk.Utilities;

namespace PayNlSdk;

/// <summary>
/// Provides access to language-related endpoints.
/// </summary>
public class Language : ILanguage
{
    private readonly IClient _webClient;

    /// <inheritdoc />
    public Language(IClient webClient)
    {
        _webClient = webClient;
    }

    /// <inheritdoc />
    public GetAllResult GetAll()
    {
        var response = _webClient.PerformRequest(new GetAllRequest());
        return JsonSerialization.Deserialize<GetAllResult>(response);
    }
}

/// <summary>
/// Contract for working with language endpoints.
/// </summary>
public interface ILanguage
{
    GetAllResult GetAll();
}

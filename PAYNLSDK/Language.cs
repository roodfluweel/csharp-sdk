using PayNlSdk.Api.Alliance.GetMerchant;
using PayNlSdk.Api.Language;
using PayNlSdk.Net;
using PayNlSdk.Utilities;

namespace PayNlSdk;

/// <summary>
/// This is a part of the alliance SDK
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
    public GetMerchantResult GetAll()
    {
        var response = _webClient.PerformRequest(new GetAllRequest());
        return JsonSerialization.Deserialize<GetMerchantResult>(response);
    }
}

/// <summary>
/// 
/// </summary>
public interface ILanguage
{
    GetMerchantResult GetAll();
}
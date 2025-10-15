using PayNLSdk.Api.Alliance.GetMerchant;
using PayNLSdk.Api.Language;
using PayNLSdk.Net;
using PayNLSdk.Utilities;

namespace PayNLSdk;

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
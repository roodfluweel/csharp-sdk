using PayNLSdk.Net;
using PayNLSdk.API.Alliance.GetMerchant;
using PayNLSdk.API.Language;

namespace PayNLSdk
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class LanguageClient : ILanguage
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Create a new instance for the language client
        /// </summary>
        /// <param name="webClient"></param>
        public LanguageClient(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public PayNLSdk.API.Language.GetAllResult GetAll()
        {
            var response = _webClient.PerformRequest(new GetAllRequest());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayNLSdk.API.Language.GetAllResult>(response);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILanguage
    {
        PayNLSdk.API.Language.GetAllResult GetAll();
    }
}

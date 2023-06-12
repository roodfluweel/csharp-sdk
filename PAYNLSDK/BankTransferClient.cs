using PayNLSdk.Net;

namespace PayNLSdk
{
    /// <inheritdoc />
    public class BankTransferClient : IBankTransferClient
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Create a new BankTransfer api client
        /// </summary>
        /// <param name="webClient"></param>
        public BankTransferClient(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public API.BankTransfer.Add.Response Add(PayNLSdk.API.BankTransfer.Add.Request request)
        {
            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <inheritdoc />
        public API.BankTransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.BankTransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            _webClient.PerformRequest(request);
            return request.Response;
        }
    }
}

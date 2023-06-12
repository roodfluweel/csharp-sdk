namespace PayNLSdk
{
    /// <summary>
    /// Initiate a bank transfer to a IBAN account
    /// </summary>
    public interface IBankTransferClient
    {
        /// <summary>
        /// Initiate an IBAN bank transfer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        API.BankTransfer.Add.Response Add(PayNLSdk.API.BankTransfer.Add.Request request);

        /// <summary>
        /// Initiate an IBAN bank transfer
        /// </summary>
        /// <param name="amount">The amount to be paid should be given in cents. For example € 3.50 becomes 350.</param>
        /// <param name="bankAccountHolder">The name of the customer</param>
        /// <param name="bankAccountNumber">The bankaccount number of the customer</param>
        /// <param name="bankAccountBic">The BIC of the bank</param>
        /// <returns></returns>
        API.BankTransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic);
    }
}

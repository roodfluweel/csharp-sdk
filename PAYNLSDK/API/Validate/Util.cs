using Newtonsoft.Json;
using PayNLSdk.Net;
using System;
using System.Diagnostics.Contracts;

namespace PayNLSdk.API.Validate
{
    /// <summary>
    /// Utility methods which you can use to validate your input data
    /// </summary>
    public class Util
    {
        private readonly IClient _client;

        private JsonSerializerSettings serializerSettings;

        /// <summary>
        /// settings for the JSON serializer
        /// </summary>
        public JsonSerializerSettings SerializerSettings
        {
            get
            {
                if (serializerSettings != null)
                {
                    return serializerSettings;
                }

                serializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                return serializerSettings;
            }
            set => serializerSettings = value;
        }

        /// <summary>
        /// Creates a new instance from the Utility class
        /// </summary>
        /// <param name="client"></param>
        public Util(IClient client) : this(client, null)
        {
        }

        /// <summary>
        /// Creates a new instance from the Utility class
        /// </summary>
        /// <param name="client"></param>
        /// <param name="serializerSettings"></param>
        public Util(IClient client, JsonSerializerSettings serializerSettings)
        {
            _client = client;
            SerializerSettings = serializerSettings;
        }

        /// <summary>
        /// use the payNl service to validate the ipaddress which called you
        /// </summary>
        /// <param name="ipAddress">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidatePayIP(string ipAddress)
        {
            IsPayServerIp.Request request = new IsPayServerIp.Request();
            request.IpAddress = ipAddress;
            _client.PerformRequest(request);
            return request.Response.result;
        }

        /// <summary>
        /// use the payNl service to validate the bank account
        /// </summary>
        /// <param name="bankAccountNumber">an input string</param>
        /// <param name="international">true if it is an international number</param>
        /// <returns>true if it matches</returns>
        public bool ValidateBankAccountNumber(string bankAccountNumber, bool international)
        {
            if (international)
            {
                BankAccountNumberInternational.Request request = new BankAccountNumberInternational.Request();
                request.BankAccountNumber = bankAccountNumber;
                _client.PerformRequest(request);
                return request.Response.Result;
            }
            else
            {
                BankAccountNumber.Request request = new BankAccountNumber.Request();
                request.BankAccountNumber = bankAccountNumber;
                _client.PerformRequest(request);
                return request.Response.result;
            }
        }

        /// <summary>
        /// use the payNl service to validate the IBAN number
        /// </summary>
        /// <param name="iban">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidateIBAN(string iban)
        {
            IBAN.Request request = new IBAN.Request();
            request.IBAN = iban;
            _client.PerformRequest(request);
            return request.Response.result;
        }

        /// <summary>
        /// use the payNl service to validate the SWIFT number
        /// </summary>
        /// <param name="swift">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidateSWIFT(string swift)
        {
            SWIFT.Request request = new SWIFT.Request();
            request.SWIFT = swift;
            _client.PerformRequest(request);
            return request.Response.result;
        }

        /// <summary>
        /// use the payNl service to validate the KVK number
        /// </summary>
        /// <param name="kvk">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidateKVK(string kvk)
        {
            KVK.Request request = new KVK.Request();
            request.KVK = kvk;
            _client.PerformRequest(request);
            return request.Response.result;
        }

        /// <summary>
        /// use the payNl service to validate the VAT number
        /// </summary>
        /// <param name="vat">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidateVAT(string vat)
        {
            VAT.Request request = new VAT.Request();
            request.VAT = vat;
            _client.PerformRequest(request);
            return request.Response.result;
        }

        /// <summary>
        /// use the payNl service to validate the SOFI number
        /// </summary>
        /// <param name="sofi">an input string</param>
        /// <returns>true if it matches</returns>
        public bool ValidateSOFI(string sofi)
        {
            SOFI.Request request = new SOFI.Request();
            request.SOFI = sofi;
            _client.PerformRequest(request);
            return request.Response.result;
        }

    }
}

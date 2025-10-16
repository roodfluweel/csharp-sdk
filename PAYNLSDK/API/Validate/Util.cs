using PayNlSdk.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Api.Validate;

public class Util
{
    public IClient Client { get; set; }

    private JsonSerializerOptions? serializerOptions;
    public JsonSerializerOptions SerializerOptions
    {
        get
        {
            if (serializerOptions == null)
            {
                serializerOptions = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
            }
            return serializerOptions;
        }
        set
        {
            serializerOptions = value;
        }
    }

    public Util(IClient client) : this(client, null)
    {
    }

    public Util(IClient client, JsonSerializerOptions? serializerOptions)
    {
        Client = client;
        SerializerOptions = serializerOptions ?? new JsonSerializerOptions();
    }

    public bool ValidatePayIP(string ipAddress)
    {
        IsPayServerIp.Request request = new IsPayServerIp.Request();
        request.IpAddress = ipAddress;
        Client.PerformRequest(request);
        return request.Response.result;
    }

    public bool ValidateBankAccountNumber(string bankAccountNumber, bool international)
    {
        if (international)
        {
            BankAccountNumberInternational.Request request = new BankAccountNumberInternational.Request();
            request.BankAccountNumber = bankAccountNumber;
            Client.PerformRequest(request);
            return request.Response.Result;
        }
        else
        {
            BankAccountNumber.Request request = new BankAccountNumber.Request();
            request.BankAccountNumber = bankAccountNumber;
            Client.PerformRequest(request);
            return request.Response.result;
        }
    }

    public bool ValidateIBAN(string iban)
    {
        IBAN.Request request = new IBAN.Request();
        request.IBAN = iban;
        Client.PerformRequest(request);
        return request.Response.result;
    }

    public bool ValidateSWIFT(string swift)
    {
        SWIFT.Request request = new SWIFT.Request();
        request.SWIFT = swift;
        Client.PerformRequest(request);
        return request.Response.result;
    }

    public bool ValidateKVK(string kvk)
    {
        KVK.Request request = new KVK.Request();
        request.KVK = kvk;
        Client.PerformRequest(request);
        return request.Response.result;
    }

    public bool ValidateVAT(string vat)
    {
        VAT.Request request = new VAT.Request();
        request.VAT = vat;
        Client.PerformRequest(request);
        return request.Response.result;
    }

    public bool ValidateSOFI(string sofi)
    {
        SOFI.Request request = new SOFI.Request();
        request.SOFI = sofi;
        Client.PerformRequest(request);
        return request.Response.result;
    }

}

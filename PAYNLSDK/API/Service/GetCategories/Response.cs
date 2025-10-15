using PayNLSdk.Objects;

namespace PayNLSdk.Api.Service.GetCategories;

public class Response : ResponseBase
{
    public ServiceCategory[] ServiceCategories { get; set; }
}

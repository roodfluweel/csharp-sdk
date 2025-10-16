using PayNlSdk.Objects;

namespace PayNlSdk.Api.Service.GetCategories;

public class Response : ResponseBase
{
    public ServiceCategory[] ServiceCategories { get; set; }
}

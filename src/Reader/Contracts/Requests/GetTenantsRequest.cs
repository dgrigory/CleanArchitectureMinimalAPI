using MinimalApiExtensions.Interfaces;

namespace Reader.Contracts.Requests;

public class GetTenantsRequest : IHttpRequest
{
    public string? Name { get; set; }
}
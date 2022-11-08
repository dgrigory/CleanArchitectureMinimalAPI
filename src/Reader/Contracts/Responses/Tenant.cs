using MinimalApiExtensions.Interfaces;

namespace Reader.Contracts.Responses;

public class Tenant
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
}
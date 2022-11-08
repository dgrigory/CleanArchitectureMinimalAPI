using MinimalApiExtensions;
using MinimalApiExtensions.Interfaces;
using Reader.Contracts.Requests;
using Reader.Contracts.Responses;

namespace Reader;

public class RouteMapper : IRouteMapper
{
    public static void MapRoutes(WebApplication app)
    {
        app.Get<GetTenantsRequest>("/api/tenants").Produces<List<Domain.Entities.TenantEntity>>().Validates<GetTenantsRequest>();
    }
}

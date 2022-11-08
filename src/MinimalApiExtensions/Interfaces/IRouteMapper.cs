using Microsoft.AspNetCore.Builder;

namespace MinimalApiExtensions.Interfaces;

public interface IRouteMapper
{
    public static abstract void MapRoutes(WebApplication app);
}
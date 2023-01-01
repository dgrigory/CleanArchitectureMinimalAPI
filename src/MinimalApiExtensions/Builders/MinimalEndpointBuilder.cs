using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MinimalApiExtensions.Filters;
using MinimalApiExtensions.Interfaces;

namespace MinimalApiExtensions.Builders;

public class MinimalEndpointBuilder
{
    private readonly RouteHandlerBuilder _routeBuilder;

    public MinimalEndpointBuilder(RouteHandlerBuilder routeBuilder)
    {
        _routeBuilder = routeBuilder;
    }

    public MinimalEndpointBuilder Produces<TResponse>()
    {
        _routeBuilder.Produces<TResponse>();
        return this;
    }

    public MinimalEndpointBuilder Validates<TRequest>() where TRequest : class
    {
        _routeBuilder.AddEndpointFilter<ValidationFilter<TRequest>>();
        return this;
    }
}
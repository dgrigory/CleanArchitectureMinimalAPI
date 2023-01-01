using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MinimalApiExtensions.Builders;
using MinimalApiExtensions.Filters;
using MinimalApiExtensions.Interfaces;

namespace MinimalApiExtensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplication UseMinimalApis<TMapper>(this WebApplication app) where TMapper : IRouteMapper
    {
        TMapper.MapRoutes(app);
        return app;
    }

    public static MinimalEndpointBuilder Get<TRequest>(this WebApplication app, string route) where TRequest : class, IHttpRequest
    {
        return new MinimalEndpointBuilder(app.MapGet(route,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
        );
    }

    public static RouteHandlerBuilder Post<TRequest, TResponse>(this WebApplication app, string route) where TRequest : class, IHttpRequest
    {
        return app.MapPost(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
            .Produces<TResponse>()
            .AddEndpointFilter<ValidationFilter<TRequest>>();
    }
}
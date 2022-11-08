using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiExtensions.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddMinimalApis(this IServiceCollection services, Type marker)
    {
        services.AddMediatR(x => x.AsScoped(), marker);
    }
}
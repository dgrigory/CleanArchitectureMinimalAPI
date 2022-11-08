using Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Store.Connection;
using Store.Implementation;

namespace Store;
public static class DependencyInjection
{
    public static IServiceCollection AddStore(this IServiceCollection services)
    {
        services.AddSingleton(sp => new MongoClient(sp.GetRequiredService<IOptionsMonitor<MongoConfigurationOptions>>().CurrentValue.GetSettings()));
        services.AddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
        services.AddSingleton<IRepository<TenantEntity>, TenantRepository>();
        return services;
    }
}

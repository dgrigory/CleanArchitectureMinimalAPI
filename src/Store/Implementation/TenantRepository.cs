using System.Runtime.CompilerServices;
using Common.Interfaces;
using Domain;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Store.Connection;

namespace Store.Implementation;
public class TenantRepository : BaseMongoRepository<TenantEntity>, IRepository<TenantEntity>
{
    public TenantRepository(IMongoDatabaseFactory databaseProvider, IRemoteFunctionDiscovery functionDiscovery) :
    base(databaseProvider, "assets", functionDiscovery)
    {
    }

    public async Task<List<TenantEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        var cursor = await collection.FindAsync(FilterDefinition<TenantEntity>.Empty, cancellationToken: cancellationToken);
        return await cursor.ToListAsync(cancellationToken);
    }

    public Task<List<TenantEntity>> GetByFilter(Filter<TenantEntity> filter, CancellationToken cancellationToken = default)
    {
        var query = filter.Query(collection.AsQueryable());
        return query.ToListAsync(cancellationToken);
    }

    public async Task<TenantEntity> GetById(ObjectId id, CancellationToken cancellationToken = default)
    {
        var cursor = await collection.FindAsync(item => item.Id == id, cancellationToken: cancellationToken);
        return await cursor.FirstAsync(cancellationToken);
    }

    public Task<long> GetCountByFilter(Filter<TenantEntity> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
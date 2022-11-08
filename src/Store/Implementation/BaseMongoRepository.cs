using MongoDB.Driver;
using Common.Interfaces;
using Domain;
using Store.Connection;

namespace Store.Implementation;
public abstract class BaseMongoRepository<T> where T : Entity
{
    protected readonly IMongoCollection<T> collection;
    protected readonly IRemoteFunctionDiscovery functionDiscovery;

    protected BaseMongoRepository(IMongoDatabaseFactory databaseProvider, string collectionName, IRemoteFunctionDiscovery functionDiscovery)
    {
        collection = databaseProvider.CreateDatabase().GetCollection<T>(collectionName);
        this.functionDiscovery = functionDiscovery;
    }
}
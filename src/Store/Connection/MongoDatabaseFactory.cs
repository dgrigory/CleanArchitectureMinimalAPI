using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Store.Connection;
public class MongoDatabaseFactory : IMongoDatabaseFactory
{
    private readonly IOptionsMonitor<MongoConfigurationOptions> _configProvider;
    private readonly MongoClient _client;

    public MongoDatabaseFactory(IOptionsMonitor<MongoConfigurationOptions> configProvider, MongoClient client)
    {
        _configProvider = configProvider;
        _client = client;
    }

    public IMongoDatabase CreateDatabase()
    {
        var config = _configProvider.CurrentValue;
        return _client.GetDatabase(config.Database);
    }
}
using System.Net;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Compression;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Linq;

namespace Store.Connection;

public record MongoConfigurationOptions
{
    public string Host { get; init; } = "localhost";
    public int Port { get; init; } = 27017;
    public string Database { get; init; } = "";
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string AuthenticationDatabase { get; init; } = "admin";

    public MongoClientSettings GetSettings()
    {
        var mongoSettings = new MongoClientSettings
        {
            Servers = new List<MongoServerAddress>
            {
                new MongoServerAddress(Host, Port)
            },
            MaxConnectionPoolSize = 100,
            Compressors = new List<CompressorConfiguration>
            {
                new CompressorConfiguration(CompressorType.Zlib)
            }
        };

        if (Username is not null && Password is not null)
        {
            mongoSettings.Credential = MongoCredential.CreateCredential(AuthenticationDatabase, Username, Password);
        }

        return mongoSettings;
    }
}
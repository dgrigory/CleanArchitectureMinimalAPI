using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class TenantEntity : Entity
{
    [BsonElement("name")]
    public string Name { get; set; } = "";
}
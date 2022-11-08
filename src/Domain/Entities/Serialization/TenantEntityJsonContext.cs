using System.Text.Json.Serialization;

namespace Domain.Entities.Serialization;

[JsonSerializable(typeof(TenantEntity))]
public partial class TenantEntityJsonContext : JsonSerializerContext
{
}

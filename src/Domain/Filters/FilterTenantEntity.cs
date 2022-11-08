using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enums;
using MongoDB.Driver.Linq;

namespace Domain.Filters;
public record FilterTenantEntity : Filter<TenantEntity>
{
    public string? Name { get; set; }


    public override Expression<Func<TenantEntity, object>> SortingField => x => x.Name;

    public override IMongoQueryable<TenantEntity> Query(IMongoQueryable<TenantEntity> query)
    {
        if (Name is not null)
        {
            query = query.Where(x => x.Name == Name);
        }

        return base.Query(query);
    }
}
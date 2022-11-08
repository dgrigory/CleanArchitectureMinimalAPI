using System.Linq.Expressions;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace Domain;
public abstract record Filter<TSource> where TSource : Entity
{
    public int Limit { get; set; } = 100;

    public int Skip { get; set; } = 0;

    public ObjectId? Id { get; set; }

    public SortingDirection SortingDirection { get; set; } = SortingDirection.DESCENDING;
    public abstract Expression<Func<TSource, object>> SortingField { get; }

    public virtual IMongoQueryable<TSource> Query(IMongoQueryable<TSource> query)
    {
        if (Id is not null)
        {
            query = query.Where(x => x.Id == Id);
        }

        query = SortingDirection == SortingDirection.ASCENDING ? query.OrderBy(SortingField) : query.OrderByDescending(SortingField);
        return query.Skip(Skip).Take(Limit);
    }
}
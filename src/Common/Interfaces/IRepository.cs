using Domain;
using MongoDB.Bson;

namespace Common.Interfaces;
public interface IRepository<T> where T : Entity
{
    Task<List<T>> GetAll(CancellationToken cancellationToken = default);
    Task<List<T>> GetByFilter(Filter<T> filter, CancellationToken cancellationToken = default);
    Task<long> GetCountByFilter(Filter<T> filter, CancellationToken cancellationToken = default);
    Task<T> GetById(ObjectId id, CancellationToken cancellationToken = default);
}
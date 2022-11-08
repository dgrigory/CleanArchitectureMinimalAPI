using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Application.Interfaces;

public interface ITenantService
{
    Task<List<TenantEntity>> GetAll(CancellationToken cancellationToken = default);

    Task<List<TenantEntity>> GetByFilter(Filter<TenantEntity> filter, CancellationToken cancellationToken = default);
}
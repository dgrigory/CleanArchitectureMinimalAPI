using Application.Interfaces;
using Common.Interfaces;
using Domain;
using Domain.Entities;

namespace Application.Implementations;

public class TenantService : ITenantService
{
    private readonly IRepository<TenantEntity> repository;

    public TenantService(IRepository<TenantEntity> repository)
    {
        this.repository = repository;
    }

    public Task<List<TenantEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        return repository.GetAll(cancellationToken);
    }

    public Task<List<TenantEntity>> GetByFilter(Filter<TenantEntity> filter, CancellationToken cancellationToken = default)
    {
        return repository.GetByFilter(filter, cancellationToken);
    }
}
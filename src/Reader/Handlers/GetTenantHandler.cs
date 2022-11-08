using Application.Interfaces;
using Domain.Filters;
using MediatR;
using Reader.Contracts.Requests;

namespace Reader.Handlers;

public class GetTenantHandler : IRequestHandler<GetTenantsRequest, IResult>
{
    private readonly ITenantService _dataService;

    public GetTenantHandler(ITenantService dataService)
    {
        _dataService = dataService;
    }

    public async Task<IResult> Handle(GetTenantsRequest request, CancellationToken cancellationToken)
    {
        var data = await _dataService.GetByFilter(new FilterTenantEntity
        {
            Name = request.Name
        }, cancellationToken);

        return Results.Ok(data);
    }
}
using FluentValidation;
using Reader.Contracts.Requests;

namespace Reader.Contracts.Validation;

public class GetTenantsRequestValidator : AbstractValidator<GetTenantsRequest>
{
    public GetTenantsRequestValidator()
    {
        //RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId is required");
        //RuleFor(x => x.InstanceId).NotNull().WithMessage("InstanceId is required");
    }
}
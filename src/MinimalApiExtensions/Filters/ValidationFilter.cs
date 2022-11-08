using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace MinimalApiExtensions.Filters;

public class ValidationFilter<T> : IRouteHandlerFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        if (context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T)) is not T validatable)
        {
            return await next(context);
        }

        var validationResult = await _validator.ValidateAsync(validatable);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => new { error = x.ErrorMessage });
            return Results.BadRequest(errors);
        }
        return await next(context);
    }
}
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MinimalApiExtensions.Interfaces;

public interface IHttpRequest : IRequest<IResult>
{
}
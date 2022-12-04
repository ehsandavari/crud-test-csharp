using MediatR;

namespace Application.Common.Mediator;

public interface IBaseQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IBaseQuery<TResponse>
{
}
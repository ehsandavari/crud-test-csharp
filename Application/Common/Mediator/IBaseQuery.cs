using MediatR;

namespace Application.Common.Mediator;

public interface IBaseQuery<out TResponse> : IRequest<TResponse>
{
}
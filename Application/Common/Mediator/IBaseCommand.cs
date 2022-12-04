using MediatR;

namespace Application.Common.Mediator;

public interface IBaseCommand<out TData> : IRequest<TData>
{
}
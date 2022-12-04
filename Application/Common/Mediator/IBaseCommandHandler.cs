using MediatR;

namespace Application.Common.Mediator;

public interface IBaseCommandHandler<in TCommand, TResponseData> : IRequestHandler<TCommand, TResponseData>
    where TCommand : IBaseCommand<TResponseData>
{
}
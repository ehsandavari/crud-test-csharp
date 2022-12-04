using MediatR;

namespace Application.Common.Mediator;

public interface IBaseNotificationHandler<in TNotification> : INotificationHandler<TNotification>
    where TNotification : IBaseNotification
{
}
using MediatR;

namespace domainEvents.Interfaces
{
    public interface IHandle<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
        // Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
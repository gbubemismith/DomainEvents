using MediatR;

namespace domainEvents.Interfaces
{

    public interface IDomainEvent : INotification
    {
        //we can use this instead of BaseDomainEvent
        //events would then inherit from IDomainEvent
    }
}
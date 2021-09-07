using System;
using MediatR;

namespace domainEvents.Interfaces
{
    public interface IDomainEvent : INotification
    {
        DateTime DateTimeOccured { get; }
    }
}
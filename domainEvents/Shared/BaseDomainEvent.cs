using System;
using MediatR;

namespace domainEvents.Shared
{
    public class BaseDomainEvent : INotification
    {
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
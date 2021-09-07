using System;
using System.Collections.Generic;
using MediatR;

namespace domainEvents.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
        List<INotification> Events { get; }
    }
}
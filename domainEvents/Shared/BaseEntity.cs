using System.Collections.Generic;
using domainEvents.Interfaces;

namespace domainEvents.Shared
{
    //aggregate root
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public List<IDomainEvent> Events = new List<IDomainEvent>();
    }
}
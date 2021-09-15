using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace domainEvents.Entities
{
    public abstract class AggregateRoot
    {
        private readonly List<INotification> _events = new List<INotification>();
        public AggregateId Id { get; protected set; }
        public int Version { get; protected set; }
        public IEnumerable<INotification> Events => _events;

        protected void AddEvent(INotification @event)
        {
            if (!_events.Any())
                Version++;

            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domainEvents.Interfaces;
using domainEvents.Shared;
using MediatR;

namespace domainEvents.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        private readonly IMediator _mediator;

        public Repository(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly Dictionary<Guid, TEntity> _entities = new Dictionary<Guid, TEntity>();

        public object ConsoleWriter { get; private set; }

        public TEntity GetById(Guid id)
        {
            return _entities[id];
        }

        public List<TEntity> GetAll()
        {
            return _entities.Values.ToList();
        }

        public async Task Save(TEntity entity)
        {
            _entities[entity.Id] = entity;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[DATABASE] Saved entity {0}", entity.Id.ToString());

            var eventsCopy = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in eventsCopy)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }
    }
}
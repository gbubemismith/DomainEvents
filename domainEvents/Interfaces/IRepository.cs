using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domainEvents.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        Task Save(TEntity entity);
    }
}
using System.Collections.Generic;
using Lab1.Entities;

namespace Lab1.Interfaces
{
    public interface IGenericCrudService<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetOneById(TId id);

        void Create(TEntity entity);

        void DeleteById(TId id);

        void Update(TEntity entity);
    }
}
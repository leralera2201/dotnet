using System.Collections;
using System.Collections.Generic;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetOneById(TId id);

        void Create(TEntity entity);

        void DeleteById(TId id);

        void Update(TEntity entity);
    }
}
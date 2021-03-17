using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetOneById(TId id);

        Task<TEntity> Create(TEntity entity);

        Task<int> DeleteById(TId id);

        Task<TEntity> Update(TEntity entity);
    }
}
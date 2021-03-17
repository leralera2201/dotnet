using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces
{
    public interface IGenericCrudService<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetOneById(TId id);

        Task<TEntity> Create(TEntity entity);

        Task<int> DeleteById(TId id);

        Task<TEntity> Update(TEntity entity);
    }
}
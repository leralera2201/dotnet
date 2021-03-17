using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _entities;

        public GenericRepository(EfConfig.MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetOneById(TId id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<int> DeleteById(TId id)
        {
            TEntity entity = await _entities.FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return await SaveChanges();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _entities.Update(entity);
            await SaveChanges();
            return entity;
        }

        private async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
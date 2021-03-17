using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class StoppageRepository : GenericRepository<Stoppage, int>, IStoppageRepository
    {
        public StoppageRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Stoppage>> GetAll()
        {
            return await _entities.Include(s => s.Station).ToListAsync();
        }

        public new async Task<Stoppage> GetOneById(int id)
        {
            return await _entities.Include(s => s.Station).FirstAsync((s => s.Id.Equals(id)));
        }
    }
}
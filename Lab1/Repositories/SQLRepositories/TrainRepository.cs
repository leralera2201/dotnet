using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class TrainRepository : GenericRepository<Train, int>, ITrainRepository
    {
        public TrainRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Train>> GetAll()
        {
            return await _entities.Include(t => t.Routes).ToListAsync();
        }

        public new async Task<Train> GetOneById(int id)
        {
            return await _entities.Include(t => t.Routes).FirstAsync((t => t.Id.Equals(id)));
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class StationRepository : GenericRepository<Station, int>, IStationRepository
    {
        public StationRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Station>> GetAll()
        {
            return await _entities.Include(s => s.Stoppages).ToListAsync();
        }

        public new async Task<Station> GetOneById(int id)
        {
            return await _entities.Include(s => s.Stoppages).FirstAsync((s => s.Id.Equals(id)));
        }
    }
}
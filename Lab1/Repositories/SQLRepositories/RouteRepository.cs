using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class RouteRepository : GenericRepository<Route, int>, IRouteRepository
    {
        public RouteRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Route>> GetAll()
        {
            return await _entities
                .Include(r => r.Train)
                .Include(r => r.Stoppages)
                .Include(r => r.Tickets)
                .ToListAsync();
        }

        public new async Task<Route> GetOneById(int id)
        {
            return await _entities
                .Include(r => r.Train)
                .Include(r => r.Stoppages)
                .Include(r => r.Tickets)
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}
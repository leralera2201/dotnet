using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _entities.Include(t => t.User).Include(t => t.Route).ToListAsync();
        }

        public new async Task<Ticket> GetOneById(int id)
        {
            return await _entities.Include(t => t.User).Include(t => t.Route).FirstAsync((t => t.Id.Equals(id)));
        }
    }
}
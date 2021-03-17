using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories.SQLRepositories
{
    public class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;

namespace Lab1.Repositories.SQLRepositories
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Order>> GetAll(OrderParameters parameters)
        {
            return await _entities
                .Include(r => r.Client)
                .Include(r => r.Product)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public new async Task<Order> GetOneById(int id)
        {
            return await _entities
                .Include(r => r.Client)
                .Include(r => r.Product)
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}
using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
        public Task<IEnumerable<Order>> GetAll(OrderParameters parameters);
    }
}
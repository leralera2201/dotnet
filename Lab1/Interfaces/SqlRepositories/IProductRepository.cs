using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        public Task<IEnumerable<Product>> GetAll(ProductParameters parameters);
    }
}
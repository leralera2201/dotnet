using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category, int>
    {
        public Task<IEnumerable<Category>> GetAll(CategoryParameters parameters);

    }
}
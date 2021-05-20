using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface ITagRepository : IGenericRepository<Tag, int>
    {
        public Task<IEnumerable<Tag>> GetAll(TagParameters parameters);
    }
}
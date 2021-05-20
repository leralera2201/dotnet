using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;

namespace Lab1.Repositories.SQLRepositories
{
    public class TagRepository : GenericRepository<Tag, int>, ITagRepository
    {
        public TagRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Tag>> GetAll(TagParameters parameters)
        {
            return await _entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public new async Task<Tag> GetOneById(int id)
        {
            return await _entities
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}
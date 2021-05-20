using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;

namespace Lab1.Repositories.SQLRepositories
{
    public class ClientRepository : GenericRepository<Client, int>, IClientRepository
    {
        public ClientRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Client>> GetAll(ClientParameters parameters)
        {
            return await _entities
                .Include(r => r.User)
                 .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public new async Task<Client> GetOneById(int id)
        {
            return await _entities
                .Include(r => r.User)
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}
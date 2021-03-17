using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories.SQLRepositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<User>> GetAll()
        {
            return await _entities.Include(u => u.Tickets).ToListAsync();

        }

        public new async Task<User> GetOneById(int id)
        {
            return await _entities.Include(u => u.Tickets).FirstAsync((u => u.Id.Equals(id)));
        }
    }
}
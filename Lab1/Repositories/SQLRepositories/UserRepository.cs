using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;

namespace Lab1.Repositories.SQLRepositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<User>> GetAll(UserParameters parameters)
        {
            var list = await _entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToListAsync();

            if (!string.IsNullOrEmpty(parameters.Email))
            {
                list = list.FindAll(station => station.Email == parameters.Email);
            }

            return list;

        }

        public new async Task<User> GetOneById(int id)
        {
            return await _entities.FirstAsync((u => u.Id.Equals(id)));
        }
    }
}
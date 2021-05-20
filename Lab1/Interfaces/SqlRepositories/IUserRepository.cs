using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<IEnumerable<User>> GetAll(UserParameters parameters);
    }
}
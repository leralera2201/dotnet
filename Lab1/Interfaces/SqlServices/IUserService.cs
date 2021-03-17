using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetOneById(int id);

        Task<User> Create(User entity);

        Task<int> DeleteById(int id);

        Task<User> Update(User entity);
    }
}
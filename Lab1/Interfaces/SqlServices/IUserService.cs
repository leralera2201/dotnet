using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities.Parameters;
using Lab1.DTOs.UserDTOs;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll(UserParameters parameters);

        Task<User> GetOneById(int id);

        Task<User> Create(UserRequestDto entity);

        Task<int> DeleteById(int id);

        Task<User> Update(int id, UserRequestDto entity);
    }
}
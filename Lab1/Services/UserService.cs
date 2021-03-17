using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class UserService : IUserService
    {
        IGenericRepository<User, int> _repository;

        public UserService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._userRepository;
        }
        
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<User> Create(User entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<User> Update(User entity)
        {
            return await _repository.Update(entity);
        }
    }
}
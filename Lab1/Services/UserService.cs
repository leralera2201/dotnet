using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class UserService : IUserService
    {
        IGenericRepository<User, int> _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Create(User entity)
        {
            _repository.Create(entity);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public void Update(User entity)
        {
            _repository.Update(entity);
        }
    }
}
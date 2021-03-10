using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class UserService : IUserService
    {
        IGenericRepository<UserEntity, int> _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<UserEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public UserEntity GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Create(UserEntity entity)
        {
            _repository.Create(entity);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public void Update(UserEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
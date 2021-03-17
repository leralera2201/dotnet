using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class StoppageService : IStoppageService
    {
        private IGenericRepository<Stoppage, int> _repository;

        public StoppageService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._stoppageRepository;
        }

        public async Task<IEnumerable<Stoppage>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Stoppage> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<Stoppage> Create(Stoppage entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Stoppage> Update(Stoppage entity)
        {
            return await _repository.Update(entity);
        }
    }
}
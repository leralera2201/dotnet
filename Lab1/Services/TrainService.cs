using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class TrainService : ITrainService
    {
        IGenericRepository<Train, int> _repository;

        public TrainService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._trainRepository;
        }

        public async Task<IEnumerable<Train>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Train> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<Train> Create(Train entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Train> Update(Train entity)
        {
            return await _repository.Update(entity);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class StationService : IStationService
    {
        IGenericRepository<Station, int> _repository;

        public StationService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._stationRepository;
        }
        
        public async Task<IEnumerable<Station>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Station> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<Station> Create(Station entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Station> Update(Station entity)
        {
            return await _repository.Update(entity);
        }
    }
}
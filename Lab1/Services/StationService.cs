using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class StationService : IStationService
    {
        IGenericRepository<StationEntity, int> _repository;

        public StationService(IStationRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<StationEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public StationEntity GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Create(StationEntity entity)
        {
            _repository.Create(entity);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public void Update(StationEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
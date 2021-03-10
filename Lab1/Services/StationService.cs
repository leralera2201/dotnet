using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class StationService : IStationService
    {
        IGenericRepository<Station, int> _repository;

        public StationService(IStationRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<Station> GetAll()
        {
            return _repository.GetAll();
        }

        public Station GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Create(Station entity)
        {
            _repository.Create(entity);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public void Update(Station entity)
        {
            _repository.Update(entity);
        }
    }
}
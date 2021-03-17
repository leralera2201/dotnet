using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class RouteService : IRouteService
    {
        IGenericRepository<Route, int> _repository;

        public RouteService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._routeRepository;
        }

        public async Task<IEnumerable<Route>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Route> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<Route> Create(Route entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Route> Update(Route entity)
        {
            return await _repository.Update(entity);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> GetAll();

        Task<Route> GetOneById(int id);

        Task<Route> Create(Route entity);

        Task<int> DeleteById(int id);

        Task<Route> Update(Route entity);
    }
}
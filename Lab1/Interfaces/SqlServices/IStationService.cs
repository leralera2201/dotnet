using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAll();

        Task<Station> GetOneById(int id);

        Task<Station> Create(Station entity);

        Task<int> DeleteById(int id);

        Task<Station> Update(Station entity);
    }
}
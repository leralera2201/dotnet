using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface ITrainService
    {
        Task<IEnumerable<Train>> GetAll();

        Task<Train> GetOneById(int id);

        Task<Train> Create(Train entity);

        Task<int> DeleteById(int id);

        Task<Train> Update(Train entity);
    }
}
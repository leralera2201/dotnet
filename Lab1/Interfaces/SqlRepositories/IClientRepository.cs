using Lab1.Entities;
using Lab1.Entities.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IClientRepository : IGenericRepository<Client, int>
    {
        public Task<IEnumerable<Client>> GetAll(ClientParameters parameters);
    }
}
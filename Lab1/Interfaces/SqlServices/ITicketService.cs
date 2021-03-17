using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAll();

        Task<Ticket> GetOneById(int id);

        Task<Ticket> Create(Ticket entity);

        Task<int> DeleteById(int id);

        Task<Ticket> Update(Ticket entity);
    }
}
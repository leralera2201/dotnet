using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;

namespace Lab1.Services
{
    public class TicketService : ITicketService
    {
        private IGenericRepository<Ticket, int> _repository;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork._ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Ticket> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<Ticket> Create(Ticket entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Ticket> Update(Ticket entity)
        {
            return await _repository.Update(entity);
        }
    }
}
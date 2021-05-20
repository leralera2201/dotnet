using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.ClientDTOs;
using Lab1.Entities.Parameters;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll(ClientParameters parameters);

        Task<Client> GetOneById(int id);

        Task<Client> Create(ClientRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Client> Update(int id, ClientRequestDto entity);
    }
}
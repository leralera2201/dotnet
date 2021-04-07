using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.StoppageDTOs;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IStoppageService
    {
        Task<IEnumerable<Stoppage>> GetAll();

        Task<Stoppage> GetOneById(int id);

        Task<Stoppage> Create(StoppageRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Stoppage> Update(int id, StoppageRequestDto entity);
    }
}
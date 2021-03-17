using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.StationDTOs;
using Lab1.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lab1.Interfaces.SqlServices
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAll();

        Task<Station> GetOneById(int id);

        Task<Station> Create(StationRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Station> Update(int id, StationRequestDto entity);
    }
}
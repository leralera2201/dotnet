using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.OrderDTOs;
using Lab1.Entities.Parameters;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll(OrderParameters parameters);

        Task<Order> GetOneById(int id);

        Task<Order> Create(OrderRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Order> Update(int id, OrderRequestDto entity);
    }
}
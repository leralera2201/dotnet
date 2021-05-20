using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.ProductDTOs;
using Lab1.Entities.Parameters;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(ProductParameters parameters);

        Task<Product> GetOneById(int id);

        Task<Product> Create(ProductRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Product> Update(int id, ProductRequestDto entity);
    }
}
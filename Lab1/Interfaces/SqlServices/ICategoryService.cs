using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.DTOs.CategoryDTOs;
using Lab1.Entities.Parameters;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll(CategoryParameters parameters);

        Task<Category> GetOneById(int id);

        Task<Category> Create(CategoryRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Category> Update(int id, CategoryRequestDto entity);
    }
}
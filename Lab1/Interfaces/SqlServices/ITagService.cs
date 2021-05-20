using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities.Parameters;
using Lab1.DTOs.TagDTOs;
using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAll(TagParameters parameters);

        Task<Tag> GetOneById(int id);

        Task<Tag> Create(TagRequestDto entity);

        Task<int> DeleteById(int id);

        Task<Tag> Update(int id, TagRequestDto entity);
    }
}
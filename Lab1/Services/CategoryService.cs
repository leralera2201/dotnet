using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.DTOs.CategoryDTOs;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlServices;
using Lab1.Entities.Parameters;

namespace Lab1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Category>> GetAll(CategoryParameters parameters)
        {
            return await _unitOfWork._categoryRepository.GetAll(parameters);
        }

        public async Task<Category> GetOneById(int id)
        {
            return await _unitOfWork._categoryRepository.GetOneById(id);
        }

        public async Task<Category> Create(CategoryRequestDto dto)
        {
            Category entity = _mapper.Map<CategoryRequestDto, Category>(dto);
            Category station = await _unitOfWork._categoryRepository.Create(entity);
            await _unitOfWork.SaveChanges();
            return station;
        }

        public async Task<int> DeleteById(int id)
        {
            if (!await _unitOfWork._categoryRepository.ExistsById(id))
                throw new HttpRequestException("Entity with specified id not found", null, HttpStatusCode.NotFound);
            
            int byId = await _unitOfWork._categoryRepository.DeleteById(id);
            await _unitOfWork.SaveChanges();
            return byId;
        }

        public async Task<Category> Update(int id, CategoryRequestDto dto)
        {
            Category entity = _mapper.Map<CategoryRequestDto, Category>(dto);
            entity.Id = id;
            Category station = await _unitOfWork._categoryRepository.Update(entity);
            await _unitOfWork.SaveChanges();
            return station;
        }
    }
}
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.DTOs.ProductDTOs;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlServices;
using Lab1.Entities.Parameters;

namespace Lab1.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Product>> GetAll(ProductParameters parameters)
        {
            return await _unitOfWork._productRepository.GetAll(parameters);
        }

        public async Task<Product> GetOneById(int id)
        {
            return await _unitOfWork._productRepository.GetOneById(id);
        }

        public async Task<Product> Create(ProductRequestDto dto)
        {
            Product entity = _mapper.Map<ProductRequestDto, Product>(dto);
            entity.Category = await _unitOfWork._categoryRepository.GetOneById(dto.CategoryId);

            Product route = await _unitOfWork._productRepository.Create(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }

        public async Task<int> DeleteById(int id)
        {
            if (!await _unitOfWork._productRepository.ExistsById(id))
                throw new HttpRequestException("Entity with specified id not found", null, HttpStatusCode.NotFound);
            
            int byId = await _unitOfWork._productRepository.DeleteById(id);
            await _unitOfWork.SaveChanges();
            return byId;
        }

        public async Task<Product> Update(int id, ProductRequestDto dto)
        {
            Product entity = _mapper.Map<ProductRequestDto, Product>(dto);
            entity.Id = id;
            entity.Category = await _unitOfWork._categoryRepository.GetOneById(dto.CategoryId);

            Product route = await _unitOfWork._productRepository.Update(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }
    }
}
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.DTOs.OrderDTOs;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlServices;
using Lab1.Entities.Parameters;

namespace Lab1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Order>> GetAll(OrderParameters parameters)
        {
            return await _unitOfWork._orderRepository.GetAll(parameters);
        }

        public async Task<Order> GetOneById(int id)
        {
            return await _unitOfWork._orderRepository.GetOneById(id);
        }

        public async Task<Order> Create(OrderRequestDto dto)
        {
            Order entity = _mapper.Map<OrderRequestDto, Order>(dto);
            entity.Client = await _unitOfWork._clientRepository.GetOneById(dto.ClientId);
            entity.Product = await _unitOfWork._productRepository.GetOneById(dto.ProductId);

            Order route = await _unitOfWork._orderRepository.Create(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }

        public async Task<int> DeleteById(int id)
        {
            if (!await _unitOfWork._productRepository.ExistsById(id))
                throw new HttpRequestException("Entity with specified id not found", null, HttpStatusCode.NotFound);
            
            int byId = await _unitOfWork._orderRepository.DeleteById(id);
            await _unitOfWork.SaveChanges();
            return byId;
        }

        public async Task<Order> Update(int id, OrderRequestDto dto)
        {
            Order entity = _mapper.Map<OrderRequestDto, Order>(dto);
            entity.Id = id;
            entity.Client = await _unitOfWork._clientRepository.GetOneById(dto.ClientId);
            entity.Product = await _unitOfWork._productRepository.GetOneById(dto.ProductId);

            Order route = await _unitOfWork._orderRepository.Update(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }
    }
}
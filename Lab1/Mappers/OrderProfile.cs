using AutoMapper;
using Lab1.DTOs.OrderDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestDto, Order>();
        }
    }
}
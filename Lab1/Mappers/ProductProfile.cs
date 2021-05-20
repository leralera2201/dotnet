using AutoMapper;
using Lab1.DTOs.ProductDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestDto, Product>();
        }
    }
}
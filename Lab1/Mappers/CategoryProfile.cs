using AutoMapper;
using Lab1.DTOs.CategoryDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequestDto, Category>();
        }
    }
}
using AutoMapper;
using Lab1.DTOs.TagDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagRequestDto, Tag>();
        }
    }
}
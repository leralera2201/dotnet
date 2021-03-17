using AutoMapper;
using Lab1.DTOs.StoppageDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class StoppageProfile : Profile
    {
        public StoppageProfile()
        {
            CreateMap<StoppageRequestDto, Stoppage>();
        }
    }
}
using AutoMapper;
using Lab1.DTOs.StationDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class StationProfile : Profile
    {
        public StationProfile()
        {
            CreateMap<StationRequestDto, Station>();
        }
    }
}
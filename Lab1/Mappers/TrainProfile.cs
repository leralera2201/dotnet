using AutoMapper;
using Lab1.DTOs.TrainDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class TrainProfile : Profile
    {
        public TrainProfile()
        {
            CreateMap<TrainRequestDto, Train>();
        }
    }
}
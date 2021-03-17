using AutoMapper;
using Lab1.DTOs.RouteDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<RouteRequestDto, Route>();
        }
    }
}
using AutoMapper;
using Lab1.DTOs.ClientDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientRequestDto, Client>();
        }
    }
}
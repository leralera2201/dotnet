using AutoMapper;
using Lab1.DTOs.TicketDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketRequestDto, Ticket>();
        }
    }
}
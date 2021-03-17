using AutoMapper;
using Lab1.DTOs.UserDTOs;
using Lab1.Entities;

namespace Lab1.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDto, User>();
        }
    }
}
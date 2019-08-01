using AutoMapper;
using DotnetCore.project.DTOs;
using DotnetCore.project.Models;

namespace DotnetCore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
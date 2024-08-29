using AutoMapper;
using BookingRoom.Application.Dtos.AuthenServiceDto;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping RoleService
            CreateMap<InsertUpdateServiceAsyncInputDto, Role>();

            // Mapping AuthenService
            CreateMap<RegisterAsyncInputDto, User>();

        }
    }
}

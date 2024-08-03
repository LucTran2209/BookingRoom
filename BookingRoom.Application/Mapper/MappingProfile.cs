using AutoMapper;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping RoleService
            CreateMap<InsertServiceAsyncInputDto, Role>();

        }
    }
}

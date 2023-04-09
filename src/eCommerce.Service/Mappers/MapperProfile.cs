using AutoMapper;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;

namespace eCommerce.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreationDto>().ReverseMap();

        }
    }
}

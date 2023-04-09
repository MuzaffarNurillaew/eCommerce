using AutoMapper;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;

namespace eCommerce.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreationDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreationDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();




        }
    }
}

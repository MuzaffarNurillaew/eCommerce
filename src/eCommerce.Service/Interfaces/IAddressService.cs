using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDto> CreateAsync(AddressCreationDto dto);
        Task<AddressDto> UpdateAsync(Expression<Func<Address, bool>> expression, AddressCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Address, bool>> expression);
        Task<AddressDto> GetAsync(Expression<Func<Address, bool>> expression);
        Task<List<AddressDto>> GetAllAsync(PaginationParams @params, Expression<Func<Address, bool>> expression = null);
    }
}

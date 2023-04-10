using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserCreationDto userDto);
        Task<UserDto> UpdateAsync(Expression<Func<User, bool>> expression, UserUpdateDto userDto);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<UserDto> GetAsync(Expression<Func<User, bool>> expression);
        Task<List<UserDto>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null);
    }
}

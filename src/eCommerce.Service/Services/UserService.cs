using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(UserCreationDto userDto)
        {
            var entity = await _userRepository.SelectAsync(user
                => user.Email == userDto.Email || user.Phone == userDto.Phone);

            if (entity is not null)
            {
                throw new CustomException(400, "User Already exists");
            }

            User entityToInsert = _mapper.Map<User>(userDto);

            try
            {
                entityToInsert.CreatedAt = DateTime.UtcNow;
                var insertedUser = await _userRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<UserDto>(insertedUser);

                await _userRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateAsync(Expression<Func<User, bool>> expression, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}

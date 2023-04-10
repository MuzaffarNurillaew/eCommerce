using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Extensions;
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

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var isDeleted = await _userRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching user not found");

            await _userRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<UserDto>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = _userRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<User>(@params);

            var filteredUsers = entities.ToList();

            var result = _mapper.Map<List<UserDto>>(entities);

            return await Task.FromResult(result);
        }

        public async Task<UserDto> GetAsync(Expression<Func<User, bool>> expression)
        {
            var entity = await _userRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateAsync(Expression<Func<User, bool>> expression, UserDto userDto)
        {
            var entity = await _userRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            _mapper.Map(userDto, entity, typeof(UserDto), typeof(User));

            var updatedEntity = await _userRepository.UpdateAsync(entity);
            await _userRepository.SaveAsync();

            return _mapper.Map<UserDto>(updatedEntity);
        }
    }
}

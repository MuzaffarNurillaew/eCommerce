﻿using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Users;
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

        public Task<UserDto> CreateAsync(UserCreationDto userDto)
        {
            throw new NotImplementedException();
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

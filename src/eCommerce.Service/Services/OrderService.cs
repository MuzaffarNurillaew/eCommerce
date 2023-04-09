using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Chats;
using eCommerce.Service.Dtos.Orders;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Extensions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateAsync(OrderCreationDto userDto)
        {
            var entity = await _orderRepository.SelectAsync(order
              => order.UserId == userDto.UserId);

            if (entity is not null)
            {
                throw new CustomException(400, "User Already exists");
            }

            Order entityToInsert = _mapper.Map<Order>(userDto);

            try
            {
                entityToInsert.CreatedAt = DateTime.UtcNow;
                var insertedOrder = await _orderRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<OrderDto>(insertedOrder);

                await _orderRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var isDeleted = await _orderRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching user not found");

            await _orderRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<OrderDto>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = _orderRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<Order>(@params);

            var filteredOrders = entities.ToList();

            var result = _mapper.Map<List<OrderDto>>(entities);

            return await Task.FromResult(result);
        }

        public async Task<OrderDto> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var entity = await _orderRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<OrderDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderUpdateDto userDto)
        {
            var entity = await _orderRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            _mapper.Map(userDto, entity, typeof(OrderDto), typeof(Order));

            var updatedEntity = await _orderRepository.UpdateAsync(entity);
            await _orderRepository.SaveAsync();

            return _mapper.Map<OrderDto>(updatedEntity);
        }
    }
}

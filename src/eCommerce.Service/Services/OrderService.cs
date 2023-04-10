using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Enums;
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
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderDto> CreateAsync(OrderCreationDto dto)
        {
            var entityToInsert = new Order()
            {
                UserId = dto.UserId,
                PaymentType = dto.PaymentType,
                Status = OrderStatus.Pending,
                IsPaid = false
            };
            var insertedEntity = await this._orderRepository.InsertAsync(entityToInsert);
            await this._orderRepository.SaveAsync();

            var mapperItems = this._mapper.Map<List<OrderItem>>(dto.Items);
            decimal totalMoney = 0;

            foreach (var item in mapperItems)
            {
                item.OrderId = insertedEntity.Id;
                await this._orderItemRepository.InsertAsync(item);

                var product = await this._productRepository.SelectAsync(p => p.Id == item.ProductId);
                totalMoney += item.ProductCount * product.Price;
            }

            insertedEntity.TotalPayment = totalMoney;

            await this._orderItemRepository.SaveAsync();
            await this._orderRepository.SaveAsync();

            return this._mapper.Map<OrderDto>(insertedEntity);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var isDeleted = await _orderRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching entity not found");

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
                throw new CustomException(404, "Matching entity not found");

            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<OrderDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderCreationDto dto)
        {
            var entity = await _orderRepository.SelectAsync(expression);
            
            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            while (true)
            {
                bool isDeleted = await this._orderItemRepository.DeleteAsync(oi => oi.OrderId == entity.Id);

                if (isDeleted == false)
                {
                    break;
                }
            }
            await this._orderItemRepository.SaveAsync();
            await this._orderRepository.DeleteAsync(o => o.Id == entity.Id);

            var result = await this.CreateAsync(dto);

            return result;
        }
    }
}

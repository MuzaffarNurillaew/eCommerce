using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.Dtos.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(OrderCreationDto dto);
        Task<OrderDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<OrderDto> GetAsync(Expression<Func<Order, bool>> expression);
        Task<List<OrderDto>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null);
    }
}

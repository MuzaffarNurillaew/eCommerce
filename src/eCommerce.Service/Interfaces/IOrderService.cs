using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.Dtos.Orders;
using eCommerce.Service.Dtos.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(OrderCreationDto userDto);
        Task<OrderDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderUpdateDto userDto);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<OrderDto> GetAsync(Expression<Func<Order, bool>> expression);
        Task<List<OrderDto>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null);
    }
}

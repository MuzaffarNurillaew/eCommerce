using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.Dtos.Chats;
using eCommerce.Service.Dtos.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDto> CreateAsync(PaymentCreationDto userDto);
        Task<PaymentDto> UpdateAsync(Expression<Func<Payment, bool>> expression, PaymentUpdateDto userDto);
        Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression);
        Task<PaymentDto> GetAsync(Expression<Func<Payment, bool>> expression);
        Task<List<PaymentDto>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null);
    }
}

using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentDto:Auditable
    {
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPayment { get; set; }
    }
}

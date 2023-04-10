using eCommerce.Domain.Commons;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPayment { get; set; }
    }
}

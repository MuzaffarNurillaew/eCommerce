using eCommerce.Domain.Commons;

namespace eCommerce.Service.Dtos.Orders
{
    public class OrderUpdateDto:Auditable
    {
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

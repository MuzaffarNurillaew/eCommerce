using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Products;

namespace eCommerce.Domain.Entities.Orders
{
    public class OrderItem : Auditable
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long ProductCount { get; set; }
        public decimal TotalMoneyToBePaid { get; set; }
    }
}

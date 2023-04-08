using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
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

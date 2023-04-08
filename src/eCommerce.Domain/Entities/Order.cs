using eCommerce.Domain.Commons;
using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entities
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public decimal TotalPayment { get; set; }

        public PaymentType PaymentType { get; set; }
        public OrderStatus Status { get; set; }

        public bool IsPaid { get; set; } = false;

        public ICollection<OrderItem> Items { get; set; }
    }
}

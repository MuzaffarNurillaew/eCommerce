using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Users;
using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entities.Orders
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
        public Payment Payment { get; set; }
    }
}

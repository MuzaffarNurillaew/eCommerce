using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Users;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.Dtos.Orders
{
    public class OrderDto
    {
        public long Id { get; set; }
        public User User { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public Payment Payment { get; set; }
    }
}

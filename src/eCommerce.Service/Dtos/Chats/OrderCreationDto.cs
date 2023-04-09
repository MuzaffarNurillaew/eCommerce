using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Enums;
using eCommerce.Service.Dtos.Orders;

namespace eCommerce.Service.Dtos.Chats
{
    public class OrderCreationDto
    {
        public long UserId { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}

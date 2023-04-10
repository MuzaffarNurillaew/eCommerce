using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Orders
{
    public class OrderCreationDto
    {
        [Required]
        public long UserId { get; set; }
        
        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public ICollection<OrderItemCreationDto> Items { get; set; }
    }
}

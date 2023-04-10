using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Orders
{
    public class OrderItemCreationDto
    {
        [Required]
        public long ProductId { get; set; }

        [Required, Range(1, long.MaxValue)]
        public long ProductCount { get; set; }

        [Required, Range(0.01, long.MaxValue)]
        public decimal TotalMoneyToBePaid { get; set; }
    }
}

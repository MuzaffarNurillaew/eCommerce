using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentCreationDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long OrderId { get; set; }
        [Required]
        public decimal TotalPayment { get; set; }
    }
}

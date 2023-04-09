using eCommerce.Domain.Commons;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentUpdateDto:Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
        public decimal Price { get; set; }
    }
}

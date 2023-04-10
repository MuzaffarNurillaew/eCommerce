using eCommerce.Domain.Commons;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentUpdateDto:Auditable
    {
        public decimal TotalPayment { get; set; }
    }
}

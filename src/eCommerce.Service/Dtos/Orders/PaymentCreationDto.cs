namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentCreationDto
    {
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPayment { get; set; }
    }
}

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
        public decimal Price { get; set; }
    }
}

using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;

namespace eCommerce.Service.Dtos.Orders
{
    public class PaymentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }

        public ICollection<ProductSearchTag> SearchTags { get; set; }
        public ICollection<OrderItem> Orders { get; set; }
    }
}

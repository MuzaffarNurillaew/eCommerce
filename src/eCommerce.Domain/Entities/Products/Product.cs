using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Orders;

namespace eCommerce.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public ICollection<ProductSearchTag> SearchTags { get; set; }
        public ICollection<OrderItem> Orders { get; set; }
    }
}

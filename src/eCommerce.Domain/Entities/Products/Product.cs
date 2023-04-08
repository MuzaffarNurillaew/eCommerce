using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
        public decimal Price { get; set; }

        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public ICollection<ProductSearchTag> SearchTags { get; set; }
    }
}

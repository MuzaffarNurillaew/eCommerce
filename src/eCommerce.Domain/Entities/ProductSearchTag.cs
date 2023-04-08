using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
{
    public class ProductSearchTag : Auditable
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long SearchTagId { get; set; }
        public SearchTag SearchTag { get; set; }
    }
}

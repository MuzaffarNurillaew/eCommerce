using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
{
    public class SearchTag : Auditable
    {
        public string SearchString { get; set; }
    }
}

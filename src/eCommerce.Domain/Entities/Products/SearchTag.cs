﻿using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Products
{
    public class SearchTag : Auditable
    {
        public string SearchString { get; set; }
    
        public ICollection<ProductSearchTag> ProductSearchTags { get; set; }
    }
}

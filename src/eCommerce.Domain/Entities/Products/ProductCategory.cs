﻿using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Products
{
    public class ProductCategory : Auditable
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

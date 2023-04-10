using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Products
{
    public class ProductCreationDto
    {
        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        [StringLength(100, MinimumLength = 2)]
        public string Description { get; set; }
        
        [Range(1, long.MaxValue)]
        public long Count { get; set; }

        [Range(0.01, long.MaxValue)]
        public decimal Price { get; set; }
    }
}

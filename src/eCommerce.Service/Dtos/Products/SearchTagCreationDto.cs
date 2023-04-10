using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Products
{
    public class SearchTagCreationDto
    {
        [StringLength(100)]
        public string SearchString { get; set; }
    }
}

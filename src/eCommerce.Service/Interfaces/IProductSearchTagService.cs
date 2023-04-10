using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Dtos.Products;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IProductSearchTagService
    {
        Task<ProductSearchTag> CreateAsync(ProductSearchTagCreationDto dto);
        //Task<bool> DeleteAsync(Expression<Func<ProductSearchTag, bool>> expression);
        Task<ProductSearchTag> GetAsync(Expression<Func<ProductSearchTag, bool>> expression);
    }
}

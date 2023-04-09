using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(ProductCreationDto userDto);
        Task<ProductDto> UpdateAsync(Expression<Func<Product, bool>> expression, ProductCreationDto userDto);
        Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
        Task<ProductDto> GetAsync(Expression<Func<Product, bool>> expression);
        Task<List<ProductDto>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);
    }
}

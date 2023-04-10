using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Dtos.Chats;
using eCommerce.Service.Dtos.Orders;
using eCommerce.Service.Dtos.Products;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface ISearchTagService
    {
        Task<SearchTag> CreateAsync(SearchTagCreationDto dto);
        Task<SearchTag> UpdateAsync(Expression<Func<SearchTag, bool>> expression, SearchTag userDto);
        Task<bool> DeleteAsync(Expression<Func<SearchTag, bool>> expression);
        Task<SearchTag> GetAsync(Expression<Func<SearchTag, bool>> expression);
        Task<List<SearchTag>> GetAllAsync(Expression<Func<SearchTag, bool>> expression = null);
    }
}

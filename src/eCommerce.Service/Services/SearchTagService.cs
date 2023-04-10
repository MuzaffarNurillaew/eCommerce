using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class SearchTagService : ISearchTagService
    {
        public Task<SearchTag> CreateAsync(SearchTagCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<SearchTag, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchTag>> GetAllAsync(Expression<Func<SearchTag, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<SearchTag> GetAsync(Expression<Func<SearchTag, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<SearchTag> UpdateAsync(Expression<Func<SearchTag, bool>> expression, SearchTag dto)
        {
            throw new NotImplementedException();
        }
    }

}

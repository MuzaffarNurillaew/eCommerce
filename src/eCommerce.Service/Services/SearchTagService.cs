using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class SearchTagService : ISearchTagService
    {
        public Task<SearchTagCreationDto> CreateAsync(SearchTagCreationDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<SearchTag, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchTag>> GetAllAsync(PaginationParams @params, Expression<Func<SearchTag, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<SearchTag> GetAsync(Expression<Func<SearchTag, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<SearchTag> UpdateAsync(Expression<Func<SearchTag, bool>> expression, SearchTag userDto)
        {
            throw new NotImplementedException();
        }
    }

}

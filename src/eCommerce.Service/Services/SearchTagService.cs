using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class SearchTagService : ISearchTagService
    {
        private readonly IRepository<SearchTag> _searchTagRepository;
        private readonly IMapper _mapper;

        public SearchTagService(IRepository<SearchTag> searchTagRepository, IMapper mapper)
        {
            _searchTagRepository = searchTagRepository;
            _mapper = mapper;
        }


        public async Task<SearchTag> CreateAsync(SearchTagCreationDto dto)
        {
            var entity = await this._searchTagRepository
                .SelectAsync(st => st.SearchString.Equals(dto.SearchString, StringComparison.OrdinalIgnoreCase));

            if (entity is not null)
            {
                return entity;
            }

            var insertedEntity = await this._searchTagRepository.InsertAsync(this._mapper.Map<SearchTag>(dto));
            await this._searchTagRepository.SaveAsync();

            return insertedEntity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<SearchTag, bool>> expression)
        {
            var isDeleted = await _searchTagRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching entity not found");

            await this._searchTagRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<SearchTag>> GetAllAsync(Expression<Func<SearchTag, bool>> expression = null)
            => await this._searchTagRepository.SelectAll().Where(expression).ToListAsync();

        public async Task<SearchTag> GetAsync(Expression<Func<SearchTag, bool>> expression)
        {
            var entity = await this._searchTagRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            return entity;
        }

        public async Task<SearchTag> UpdateAsync(Expression<Func<SearchTag, bool>> expression, SearchTag dto)
        {
            var entity = await this._searchTagRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            entity.SearchString = dto.SearchString;

            var updatedEntity = await this._searchTagRepository.UpdateAsync(entity);
            await this._searchTagRepository.SaveAsync();

            return updatedEntity;
        }
    }

}

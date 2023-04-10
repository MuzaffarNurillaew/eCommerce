using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class ProductSearchTagService : IProductSearchTagService
    {
        private readonly IRepository<ProductSearchTag> _productSearchTagRepository;
        private readonly IMapper _mapper;

        public ProductSearchTagService(IRepository<ProductSearchTag> productSearchTagRepository, IMapper mapper)
        {
            _productSearchTagRepository = productSearchTagRepository;
            _mapper = mapper;
        }


        public async Task<ProductSearchTag> CreateAsync(ProductSearchTagCreationDto dto)
        {
            var entity = this._mapper.Map<ProductSearchTag>(dto);

            var result = await this._productSearchTagRepository.InsertAsync(entity);

            return result;
        }

        public async Task<List<ProductSearchTag>> GetAllAsync(Expression<Func<ProductSearchTag, bool>> expression = null)
        {
            var result = this._productSearchTagRepository.SelectAll().Where(expression).ToList();

            return await Task.FromResult(result);
        }

        public async Task<ProductSearchTag> GetAsync(Expression<Func<ProductSearchTag, bool>> expression)
        {
            var entity = await _productSearchTagRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            return entity;
        }
    }
}

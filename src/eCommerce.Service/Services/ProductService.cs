using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Extensions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ISearchTagService _searchTagService;
        private readonly IProductSearchTagService _productSearchTagService;

        public ProductService(IRepository<Product> productRepository, IMapper mapper, IRepository<ProductSearchTag> productSearchTagRepository, ISearchTagService searchTagService, IProductSearchTagService productSearchTagService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _searchTagService = searchTagService;
            _productSearchTagService = productSearchTagService;
        }

        public async Task<ProductDto> AddSearchTagAsync(long productId, SearchTagCreationDto searchTag)
        {
            var entity = await this.GetAsync(p => p.Id == productId);

            var insertedTag = await this._searchTagService.CreateAsync(searchTag);

            entity.SearchTags.Add(insertedTag);
            await this._productRepository.SaveAsync();

            await this._productSearchTagService.CreateAsync(new ProductSearchTagCreationDto()
            {
                ProductId = productId,
                SearchTagId = insertedTag.Id
            });

            return entity;
        }

        public async Task<ProductDto> CreateAsync(ProductCreationDto dto)
        {
            var entity = await _productRepository.SelectAsync(product
               => product.Name == dto.Name);

            if (entity is not null)
            {
                throw new CustomException(400, "Product Already exists");
            }

            Product entityToInsert = _mapper.Map<Product>(dto);

            try
            {
                entityToInsert.CreatedAt = DateTime.UtcNow;
                var insertedProduct = await _productRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<ProductDto>(insertedProduct);

                await _productRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {

            var isDeleted = await _productRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching user not found");

            await _productRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<ProductDto>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null, string searchString = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = this._productRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<Product>(@params);

            var searchResult = new List<ProductDto>();

            if (!string.IsNullOrEmpty(searchString))
            {
                var foundEntities = entities.Where(p => p.Name.Contains(searchString)).ToList();
                searchResult.AddRange( this._mapper.Map<List<ProductDto>>(foundEntities));

                foreach(var entity in entities)
                {
                    
                }
            }
            else
            {
                var filteredProducts = entities.ToList();

                var result = _mapper.Map<List<ProductDto>>(entities);

                return await Task.FromResult(result);
            }
        }

        public async Task<ProductDto> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var entity = await _productRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching product not found");

            var result = this._mapper.Map<ProductDto>(entity);
            return result;
        }

        public async Task<ProductDto> UpdateAsync(Expression<Func<Product, bool>> expression, ProductCreationDto userDto)
        {
            var entity = await _productRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching product not found");

            _mapper.Map(userDto, entity, typeof(ProductCreationDto), typeof(Product));

            var updatedEntity = await _productRepository.UpdateAsync(entity);
            await _productRepository.SaveAsync();

            return _mapper.Map<ProductDto>(updatedEntity);
        }
    }


}

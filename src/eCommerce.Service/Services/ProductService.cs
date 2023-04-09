using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.Dtos.Products;
using eCommerce.Service.Dtos.Users;
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

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(ProductCreationDto userDto)
        {
            var entity = await _productRepository.SelectAsync(product
               => product.Name == userDto.Name );

            if (entity is not null)
            {
                throw new CustomException(400, "User Already exists");
            }

            Product entityToInsert = _mapper.Map<Product>(userDto);

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

        public async Task<List<ProductDto>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = _productRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<Product>(@params);

            var filteredProducts = entities.ToList();

            var result = _mapper.Map<List<ProductDto>>(entities);

            return await Task.FromResult(result);
        }

        public async Task<ProductDto> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var entity = await _productRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            return _mapper.Map<ProductDto>(entity);
        }

        public  async Task<ProductDto> UpdateAsync(Expression<Func<Product, bool>> expression, ProductCreationDto userDto)
        {
            var entity = await _productRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            _mapper.Map(userDto, entity, typeof(ProductDto), typeof(Product));

            var updatedEntity = await _productRepository.UpdateAsync(entity);
            await _productRepository.SaveAsync();

            return _mapper.Map<ProductDto>(updatedEntity);
        }
    }

       
}

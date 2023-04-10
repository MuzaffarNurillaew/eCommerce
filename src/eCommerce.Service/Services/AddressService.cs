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
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<AddressDto> CreateAsync(AddressCreationDto dto)
        {
            Address entityToInsert = _mapper.Map<Address>(dto);
            
            try
            {
                entityToInsert.CreatedAt = DateTime.UtcNow;
                var insertedProduct = await _addressRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<AddressDto>(insertedProduct);

                await _addressRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<Address, bool>> expression)
        {
            var isDeleted = await _addressRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching entity not found");

            await _addressRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<AddressDto>> GetAllAsync(PaginationParams @params, Expression<Func<Address, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = _addressRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<Address>(@params);

            var filteredAddresses = entities.ToList();

            var result = _mapper.Map<List<AddressDto>>(filteredAddresses);

            return await Task.FromResult(result);
        }

        public async Task<AddressDto> GetAsync(Expression<Func<Address, bool>> expression)
        {
            var entity = await _addressRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            return _mapper.Map<AddressDto>(entity);
        }

        public async Task<AddressDto> UpdateAsync(Expression<Func<Address, bool>> expression, AddressCreationDto userDto)
        {
            var entity = await _addressRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching entity not found");

            _mapper.Map(userDto, entity, typeof(AddressDto), typeof(Address));

            var updatedEntity = await _addressRepository.UpdateAsync(entity);
            await _addressRepository.SaveAsync();

            return _mapper.Map<AddressDto>(updatedEntity);
        }
    }
}

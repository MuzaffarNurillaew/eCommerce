using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.Dtos.Orders;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Extensions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<Payment> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<PaymentDto> CreateAsync(PaymentCreationDto userDto)
        {
            var entity = await _paymentRepository.SelectAsync(payment
              => payment.UserId == userDto.UserId || payment.OrderId == userDto.OrderId);

            if (entity is not null)
            {
                throw new CustomException(400, "User Already exists");
            }

            Payment entityToInsert = _mapper.Map<Payment>(userDto);

            try
            {
                entityToInsert.CreatedAt = DateTime.UtcNow;
                var insertedOrder = await _paymentRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<PaymentDto>(insertedOrder);

                await _paymentRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
        {
            var isDeleted = await _paymentRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching user not found");

            await _paymentRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<List<PaymentDto>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = _paymentRepository.SelectAll();

            entities = entities.Where(expression).ToPagedList<Payment>(@params);

            var filteredPayments = entities.ToList();

            var result = _mapper.Map<List<PaymentDto>>(entities);

            return await Task.FromResult(result);
        }

        public async Task<PaymentDto> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            var entity = await _paymentRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            return _mapper.Map<PaymentDto>(entity);
        }

        public async Task<PaymentDto> UpdateAsync(Expression<Func<Payment, bool>> expression, PaymentUpdateDto userDto)
        {
            var entity = await _paymentRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            _mapper.Map(userDto, entity, typeof(PaymentDto), typeof(Payment));

            var updatedEntity = await _paymentRepository.UpdateAsync(entity);
            await _paymentRepository.SaveAsync();

            return _mapper.Map<PaymentDto>(updatedEntity);
        }
    }
}

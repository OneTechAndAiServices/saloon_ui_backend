using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var entities = await _paymentRepository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<PaymentDto> GetByIdAsync(long id)
        {
            var entity = await _paymentRepository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<PaymentDto> AddAsync(PaymentDto dto)
        {
            var entity = MapToEntity(dto);
            await _paymentRepository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<PaymentDto> UpdateAsync(PaymentDto dto)
        {
            var entity = MapToEntity(dto);
            await _paymentRepository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _paymentRepository.GetByIdAsync(id);
            if (entity == null) return false;
            await _paymentRepository.DeleteAsync(entity);
            return true;
        }

        private PaymentDto MapToDto(Payment entity)
        {
            return new PaymentDto
            {
                Id = entity.Id,
                BookingId = entity.BookingId,
                Method = entity.Method,
                Amount = entity.Amount,
                Currency = entity.Currency,
                Status = entity.Status,
                TransactionId = entity.TransactionId,
                PaidAt = entity.PaidAt
            };
        }
        private Payment MapToEntity(PaymentDto dto)
        {
            return new Payment
            {
                Id = dto.Id,
                BookingId = dto.BookingId,
                Method = dto.Method,
                Amount = dto.Amount,
                Currency = dto.Currency,
                Status = dto.Status,
                TransactionId = dto.TransactionId,
                PaidAt = dto.PaidAt
            };
        }
    }
} 
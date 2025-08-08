using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(long id);
        Task<PaymentDto> AddAsync(PaymentDto dto);
        Task<PaymentDto> UpdateAsync(PaymentDto dto);
        Task<bool> DeleteAsync(long id);
    }
} 
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceAddOnService
    {
        Task<IEnumerable<ServiceAddOnDto>> GetAllAsync();
        Task<ServiceAddOnDto> GetByIdAsync(long serviceId, long addOnId);
        Task<ServiceAddOnDto> AddAsync(ServiceAddOnDto dto);
        Task<bool> DeleteAsync(long serviceId, long addOnId);
    }
} 
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkerServiceService
    {
        Task<IEnumerable<WorkerServiceDto>> GetAllAsync();
        Task<WorkerServiceDto> GetByIdAsync(long workerId, long serviceId);
        Task<WorkerServiceDto> AddAsync(WorkerServiceDto dto);
        Task<bool> DeleteAsync(long workerId, long serviceId);
    }
} 
using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkerServiceService : IWorkerServiceService
    {
        private static List<WorkerServiceDto> _workerServices = new List<WorkerServiceDto>();

        public async Task<IEnumerable<WorkerServiceDto>> GetAllAsync()
        {
            return await Task.FromResult(_workerServices);
        }

        public async Task<WorkerServiceDto> GetByIdAsync(long workerId, long serviceId)
        {
            return await Task.FromResult(_workerServices.FirstOrDefault(ws => ws.WorkerId == workerId && ws.ServiceId == serviceId));
        }

        public async Task<WorkerServiceDto> AddAsync(WorkerServiceDto dto)
        {
            _workerServices.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<bool> DeleteAsync(long workerId, long serviceId)
        {
            var ws = _workerServices.FirstOrDefault(x => x.WorkerId == workerId && x.ServiceId == serviceId);
            if (ws == null) return false;
            _workerServices.Remove(ws);
            return await Task.FromResult(true);
        }
    }
} 
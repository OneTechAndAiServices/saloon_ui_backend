using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceAddOnService : IServiceAddOnService
    {
        private static List<ServiceAddOnDto> _serviceAddOns = new List<ServiceAddOnDto>();

        public async Task<IEnumerable<ServiceAddOnDto>> GetAllAsync()
        {
            return await Task.FromResult(_serviceAddOns);
        }

        public async Task<ServiceAddOnDto> GetByIdAsync(long serviceId, long addOnId)
        {
            return await Task.FromResult(_serviceAddOns.FirstOrDefault(sa => sa.ServiceId == serviceId && sa.AddOnId == addOnId));
        }

        public async Task<ServiceAddOnDto> AddAsync(ServiceAddOnDto dto)
        {
            _serviceAddOns.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<bool> DeleteAsync(long serviceId, long addOnId)
        {
            var sa = _serviceAddOns.FirstOrDefault(x => x.ServiceId == serviceId && x.AddOnId == addOnId);
            if (sa == null) return false;
            _serviceAddOns.Remove(sa);
            return await Task.FromResult(true);
        }
    }
} 
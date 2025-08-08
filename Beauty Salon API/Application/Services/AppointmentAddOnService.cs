using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AppointmentAddOnService : IAppointmentAddOnService
    {
        private static List<AppointmentAddOnDto> _appointmentAddOns = new List<AppointmentAddOnDto>();

        public async Task<IEnumerable<AppointmentAddOnDto>> GetAllAsync()
        {
            return await Task.FromResult(_appointmentAddOns);
        }

        public async Task<AppointmentAddOnDto> GetByIdAsync(long appointmentId, long addOnId)
        {
            return await Task.FromResult(_appointmentAddOns.FirstOrDefault(aa => aa.AppointmentId == appointmentId && aa.AddOnId == addOnId));
        }

        public async Task<AppointmentAddOnDto> AddAsync(AppointmentAddOnDto dto)
        {
            _appointmentAddOns.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<bool> DeleteAsync(long appointmentId, long addOnId)
        {
            var aa = _appointmentAddOns.FirstOrDefault(x => x.AppointmentId == appointmentId && x.AddOnId == addOnId);
            if (aa == null) return false;
            _appointmentAddOns.Remove(aa);
            return await Task.FromResult(true);
        }
    }
} 
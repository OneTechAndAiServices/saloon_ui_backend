using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppointmentAddOnService
    {
        Task<IEnumerable<AppointmentAddOnDto>> GetAllAsync();
        Task<AppointmentAddOnDto> GetByIdAsync(long appointmentId, long addOnId);
        Task<AppointmentAddOnDto> AddAsync(AppointmentAddOnDto dto);
        Task<bool> DeleteAsync(long appointmentId, long addOnId);
    }
} 
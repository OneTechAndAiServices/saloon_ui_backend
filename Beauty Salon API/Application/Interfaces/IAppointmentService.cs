using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(long id);
        Task<AppointmentDto> UpdateAsync(AppointmentDto dto);
        Task<bool> DeleteAsync(long id);
        Task<AppointmentDto> AddAsync(AppointmentDto dto);

        // Advanced queries
        Task<IEnumerable<AppointmentDto>> GetByStatusAsync(string status);
        Task<IEnumerable<AppointmentDto>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<AppointmentDto>> GetByClientAsync(long clientId);
        Task<IEnumerable<AppointmentDto>> GetByWorkerAsync(long workerId);
    }
} 
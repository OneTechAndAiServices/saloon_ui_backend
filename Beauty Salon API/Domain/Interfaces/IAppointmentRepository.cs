using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetByStatusAsync(string status);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<Appointment>> GetByClientAsync(long clientId);
        Task<IEnumerable<Appointment>> GetByWorkerAsync(long workerId);
    }
} 
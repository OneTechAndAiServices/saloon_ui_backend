using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Appointment>> GetByStatusAsync(string status)
        {
            return await _context.Appointments.Where(a => a.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Appointments.Where(a => a.StartTime >= start && a.EndTime <= end).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByClientAsync(long clientId)
        {
            return await _context.Appointments.Where(a => a.ClientId == clientId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByWorkerAsync(long workerId)
        {
            return await _context.Appointments.Where(a => a.WorkerId == workerId).ToListAsync();
        }
    }
} 
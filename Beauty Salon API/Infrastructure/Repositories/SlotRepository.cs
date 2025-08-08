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
    public class SlotRepository : GenericRepository<Slot>, ISlotRepository
    {
        public SlotRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsForWorker(long workerId, DateTime date)
        {
            return await _context.Slots
                .Where(s => s.WorkerId == workerId && !s.IsBooked && !s.IsBlocked && s.StartTime.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Slot>> GetBlockedSlotsForWorker(long workerId)
        {
            return await _context.Slots
                .Where(s => s.WorkerId == workerId && s.IsBlocked)
                .ToListAsync();
        }

        public async Task<IEnumerable<Slot>> GetSlotsForWorkerInWeek(long workerId, DateTime weekStart)
        {
            var weekEnd = weekStart.AddDays(7);
            return await _context.Slots
                .Where(s => s.WorkerId == workerId && s.StartTime >= weekStart && s.EndTime < weekEnd)
                .ToListAsync();
        }
    }
} 
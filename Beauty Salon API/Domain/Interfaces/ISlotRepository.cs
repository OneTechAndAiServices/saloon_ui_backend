using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISlotRepository : IGenericRepository<Slot>
    {
        Task<IEnumerable<Slot>> GetAvailableSlotsForWorker(long workerId, DateTime date);
        Task<IEnumerable<Slot>> GetBlockedSlotsForWorker(long workerId);
        Task<IEnumerable<Slot>> GetSlotsForWorkerInWeek(long workerId, DateTime weekStart);
    }
} 
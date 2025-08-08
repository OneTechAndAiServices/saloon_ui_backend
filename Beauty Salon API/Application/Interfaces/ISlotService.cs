using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISlotService
    {
        Task<IEnumerable<SlotDto>> GetAllAsync();
        Task<SlotDto> GetByIdAsync(long id);
        Task<SlotDto> UpdateAsync(SlotDto dto);
        Task<bool> DeleteAsync(long id);
        Task<SlotDto> AddAsync(SlotDto dto);

        // Advanced queries
        Task<IEnumerable<SlotDto>> GetAvailableSlotsForWorker(long workerId, DateTime date);
        Task<IEnumerable<SlotDto>> GetBlockedSlotsForWorker(long workerId);
        Task<IEnumerable<SlotDto>> GetSlotsForWorkerInWeek(long workerId, DateTime weekStart);
    }
} 
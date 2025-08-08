using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;

        public SlotService(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        public async Task<IEnumerable<SlotDto>> GetAllAsync()
        {
            var entities = await _slotRepository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<SlotDto> GetByIdAsync(long id)
        {
            var entity = await _slotRepository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<SlotDto> AddAsync(SlotDto dto)
        {
            // Validation logic from AddWithValidationAsync
            // ... slot-specific validation ...
            var entity = MapToEntity(dto);
            await _slotRepository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<SlotDto> UpdateAsync(SlotDto dto)
        {
            var entity = MapToEntity(dto);
            await _slotRepository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _slotRepository.GetByIdAsync(id);
            if (entity == null) return false;
            await _slotRepository.DeleteAsync(entity);
            return true;
        }

        // Advanced queries
        public async Task<IEnumerable<SlotDto>> GetAvailableSlotsForWorker(long workerId, DateTime date)
        {
            var entities = await _slotRepository.GetAvailableSlotsForWorker(workerId, date);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<SlotDto>> GetBlockedSlotsForWorker(long workerId)
        {
            var entities = await _slotRepository.GetBlockedSlotsForWorker(workerId);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<SlotDto>> GetSlotsForWorkerInWeek(long workerId, DateTime weekStart)
        {
            var entities = await _slotRepository.GetSlotsForWorkerInWeek(workerId, weekStart);
            return entities.Select(MapToDto);
        }

        // Mapping helpers
        private SlotDto MapToDto(Slot entity)
        {
            return new SlotDto
            {
                Id = entity.Id,
                WorkerId = entity.WorkerId,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                IsBlocked = entity.IsBlocked,
                IsBooked = entity.IsBooked,
                AppointmentId = entity.AppointmentId
            };
        }

        private Slot MapToEntity(SlotDto dto)
        {
            return new Slot
            {
                Id = dto.Id,
                WorkerId = dto.WorkerId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                IsBlocked = dto.IsBlocked,
                IsBooked = dto.IsBooked,
                AppointmentId = dto.AppointmentId
            };
        }
    }
} 
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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ISlotRepository _slotRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, ISlotRepository slotRepository)
        {
            _appointmentRepository = appointmentRepository;
            _slotRepository = slotRepository;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var entities = await _appointmentRepository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<AppointmentDto> GetByIdAsync(long id)
        {
            var entity = await _appointmentRepository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<AppointmentDto> AddAsync(AppointmentDto dto)
        {
            // Validation logic from AddWithValidationAsync
            // ... appointment-specific validation ...
            var entity = MapToEntity(dto);
            await _appointmentRepository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<AppointmentDto> UpdateAsync(AppointmentDto dto)
        {
            var entity = MapToEntity(dto);
            await _appointmentRepository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _appointmentRepository.GetByIdAsync(id);
            if (entity == null) return false;
            await _appointmentRepository.DeleteAsync(entity);
            return true;
        }

        // Advanced queries
        public async Task<IEnumerable<AppointmentDto>> GetByStatusAsync(string status)
        {
            var entities = await _appointmentRepository.GetByStatusAsync(status);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var entities = await _appointmentRepository.GetByDateRangeAsync(start, end);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByClientAsync(long clientId)
        {
            var entities = await _appointmentRepository.GetByClientAsync(clientId);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByWorkerAsync(long workerId)
        {
            var entities = await _appointmentRepository.GetByWorkerAsync(workerId);
            return entities.Select(MapToDto);
        }

        // Mapping helpers
        private AppointmentDto MapToDto(Appointment entity)
        {
            return new AppointmentDto
            {
                Id = entity.Id,
                ClientId = entity.ClientId,
                WorkerId = entity.WorkerId,
                ServiceId = entity.ServiceId,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                Status = entity.Status,
                PaymentId = entity.PaymentId,
                Notes = entity.Notes,
                BookingId = entity.BookingId
            };
        }

        private Appointment MapToEntity(AppointmentDto dto)
        {
            return new Appointment
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                WorkerId = dto.WorkerId,
                ServiceId = dto.ServiceId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = dto.Status,
                PaymentId = dto.PaymentId,
                Notes = dto.Notes,
                BookingId = dto.BookingId
            };
        }
    }
} 
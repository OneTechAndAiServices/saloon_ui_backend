using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotificationLogService : INotificationLogService
    {
        private static List<NotificationLogDto> _logs = new List<NotificationLogDto>();
        private static long _nextId = 1;

        public async Task<IEnumerable<NotificationLogDto>> GetAllAsync()
        {
            return await Task.FromResult(_logs);
        }

        public async Task<NotificationLogDto> GetByIdAsync(long id)
        {
            return await Task.FromResult(_logs.FirstOrDefault(l => l.Id == id));
        }

        public async Task<NotificationLogDto> AddAsync(NotificationLogDto dto)
        {
            dto.Id = _nextId++;
            _logs.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<NotificationLogDto> UpdateAsync(NotificationLogDto dto)
        {
            var log = _logs.FirstOrDefault(l => l.Id == dto.Id);
            if (log == null) return null;
            log.NotificationId = dto.NotificationId;
            log.RecipientUserId = dto.RecipientUserId;
            log.SentAt = dto.SentAt;
            log.Status = dto.Status;
            log.ErrorMessage = dto.ErrorMessage;
            return await Task.FromResult(log);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var log = _logs.FirstOrDefault(l => l.Id == id);
            if (log == null) return false;
            _logs.Remove(log);
            return await Task.FromResult(true);
        }
    }
} 
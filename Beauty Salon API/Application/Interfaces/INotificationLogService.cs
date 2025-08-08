using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationLogService
    {
        Task<IEnumerable<NotificationLogDto>> GetAllAsync();
        Task<NotificationLogDto> GetByIdAsync(long id);
        Task<NotificationLogDto> AddAsync(NotificationLogDto dto);
        Task<NotificationLogDto> UpdateAsync(NotificationLogDto dto);
        Task<bool> DeleteAsync(long id);
    }
} 
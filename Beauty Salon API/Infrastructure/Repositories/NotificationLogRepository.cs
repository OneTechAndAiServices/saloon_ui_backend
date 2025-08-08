using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class NotificationLogRepository : GenericRepository<NotificationLog>, INotificationLogRepository
    {
        public NotificationLogRepository(ApplicationDbContext context) : base(context) { }
        // Add custom methods for NotificationLog if needed
    }
} 
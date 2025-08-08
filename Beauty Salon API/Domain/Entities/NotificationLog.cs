using System;

namespace Domain.Entities
{
    public class NotificationLog : BaseEntity
    {
        public long NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
        public long RecipientUserId { get; set; }
        public virtual ApplicationUser RecipientUser { get; set; }
        public DateTime SentAt { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
} 
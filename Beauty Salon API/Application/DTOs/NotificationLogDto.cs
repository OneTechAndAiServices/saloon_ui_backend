using System;

namespace Application.DTOs
{
    public class NotificationLogDto
    {
        public long Id { get; set; }
        public long NotificationId { get; set; }
        public long RecipientUserId { get; set; }
        public DateTime SentAt { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
} 
namespace Application.DTOs
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Placeholders { get; set; }
    }
} 
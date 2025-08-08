using System;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Type { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Placeholders { get; set; }
    }
} 
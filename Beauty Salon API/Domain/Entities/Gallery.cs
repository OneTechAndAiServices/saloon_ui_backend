using System;

namespace Domain.Entities
{
    public class Gallery : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public DateTime UploadedAt { get; set; }
    }
} 
using System;

namespace Application.DTOs
{
    public class GalleryDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public DateTime UploadedAt { get; set; }
    }
} 
using System;

namespace Application.DTOs
{
    public class BlogDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
} 
namespace Application.DTOs
{
    public class ServiceDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
} 
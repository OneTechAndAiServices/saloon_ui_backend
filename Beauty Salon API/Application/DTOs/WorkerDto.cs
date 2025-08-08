namespace Application.DTOs
{
    public class WorkerDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string Specialties { get; set; }
    }
} 